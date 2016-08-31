using System.Runtime.Serialization;

namespace mySOAP.Responses
{
    [DataContract]
    public enum StatusFlag
    {
        [EnumMember]
        Success = 1,
        [EnumMember]
        Error = 0
    }
}