using System.Runtime.Serialization;

namespace String_Based_Enums_InCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var  Role = Roles.Admin; 
           Console.WriteLine("Role Before Conversion to string: "+Role.ToString());

           // Conversion Enum to string 
           var RoleString = Role.ToString();
           var EnumToStringValue = GetEnumValue(Role);
           Console.WriteLine("Role After Conversion to string: "+RoleString);

           // Conversion string to Enum
           var RoleEnum = GetEnumFromString<Roles>(EnumToStringValue);
           Console.WriteLine("Role After Conversion to Enum: "+RoleEnum);
          
        }

        // Conversion string to Enum
        public static string GetEnumValue<T>(T enumValue) where T : Enum
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return ((EnumMemberAttribute)attributes[0]).Value;
        }

        // Conversion Enum to string
        public static T GetEnumFromString<T>(string value) where T : Enum
        {
            var type = typeof(T);
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(EnumMemberAttribute)) as EnumMemberAttribute;
                if (attribute != null && attribute.Value == value)
                {
                    return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException($"Unknown value: {value}");
        }
    }
}
