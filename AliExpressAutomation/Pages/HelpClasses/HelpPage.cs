using System;
using System.Runtime.Serialization;

namespace Pages.HelpClasses
{
    public class HelpPage
    {

        //There should be all constants:
        #region Constants

        #endregion

        #region JsonSerialibleClass
        [DataContract]
        internal class JsonHandlerClass
        {
            public JsonHandlerClass()
            {
                
            }
                [DataMember]
                public string[] Countries{get;set;}
                [DataMember]
                public string[] Courencies{get;set;}
                [DataMember]
                public string[] Wishes{get;set;}
                [DataMember]
                public string Login{get;set;}
                [DataMember]
                public string Password{get;set;}
                [DataMember]
                public string Email{get;set;}

        }
        #endregion
    }
}
