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
                //[DataMember]
            }
        }
        #endregion
    }
}
