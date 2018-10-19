using System.Runtime.Serialization;

namespace AliExpress.Helpers
{

    [DataContract]
    public struct Login
    {
        [DataMember]
        public string login;

        [DataMember]
        public string password;
        
    }
}
