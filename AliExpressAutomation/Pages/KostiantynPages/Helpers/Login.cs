using System.Runtime.Serialization;

namespace Pages.KostiantynPages.Helpers
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
