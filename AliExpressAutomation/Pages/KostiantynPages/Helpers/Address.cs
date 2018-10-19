using System.Runtime.Serialization;

namespace AliExpress.Helpers
{

    [DataContract]
    public struct Address
    {
        [DataMember]
        public string contactName;

        [DataMember]
        public string countryRegion;

        [DataMember]
        public string streetAddress;

        [DataMember]
        public string apartment;

        [DataMember]
        public string stateProvinceRegion;

        [DataMember]
        public string city;

        [DataMember]
        public string zip;

        [DataMember]
        public string mobileNoCountryCode;

        [DataMember]
        public string mobileNumber;
    }
}
