using System.Runtime.Serialization;

namespace String_Based_Enums_InCSharp
{
    [DataContract]
    public enum Roles
    {
        [EnumMember(Value = "Admin")]
        Admin,

        [EnumMember(Value = "Developer")]
        Developer,

        [EnumMember(Value = "Manager")]
        Manager,

        [EnumMember(Value = "TeamLead")]
        TeamLead
    }
}
