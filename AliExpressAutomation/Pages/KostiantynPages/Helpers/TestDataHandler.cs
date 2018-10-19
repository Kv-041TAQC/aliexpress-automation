using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Pages.KostiantynPages.Helpers
{

    public class TestDataHandler
    {
        private string dataFolder;
        private string addressJSONFilename = "ShippingAddressTestDataAddress.json";
        private string loginJSONFilename = "ShippingAddressTestDataLogin.json";

        private string addressFilePath;
        private string loginFilePath;

        public TestDataHandler(string dataFolder)
        {
            this.dataFolder = dataFolder;
        }

        public void WriteTestData()
        {
            Address address;
            address.contactName = "John Doe";
            address.countryRegion = "United States";
            address.streetAddress = "10 Test Ave";
            address.apartment = "15";
            address.stateProvinceRegion = "New York";
            address.city = "New york";
            address.zip = "11221";
            address.mobileNoCountryCode = "+1";
            address.mobileNumber = "5417543111";

            Login login;
            login.login = "skaxrfdzeajgee2w@outlook.com";
            login.password = "qLEvZxcMVU9xqdQC";

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            addressFilePath = Path.Combine(dataFolder, addressJSONFilename);
            using (FileStream fileStream = new FileStream(addressFilePath, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Address));
                ser.WriteObject(fileStream, address);
                fileStream.Close();
            }

            loginFilePath = Path.Combine(dataFolder, loginJSONFilename);
            using (FileStream fileStream = new FileStream(loginFilePath, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Login));
                ser.WriteObject(fileStream, login);
                fileStream.Close();
            }
        }

        public Address ReadAddressData()
        {
            using (FileStream fileStream = new FileStream(addressFilePath, FileMode.Open))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Address));
                Address address = (Address)ser.ReadObject(fileStream);
                fileStream.Close();
                return address;
            }
        }

        public Login ReadLoginData()
        {
            using (FileStream fileStream = new FileStream(loginFilePath, FileMode.Open))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Login));
                Login login = (Login)ser.ReadObject(fileStream);
                fileStream.Close();
                return login;
            }

        }
    }
}