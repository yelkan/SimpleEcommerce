using System.Runtime.Serialization;

namespace Inveon.Core.Enums
{
    [DataContract]
    public enum ProductStatus
    {
        [EnumMember]
        Passive = 0,
        [EnumMember]
        Active = 1,
        [EnumMember]
        StockEnd = 2,
    }
}
