using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Pages;

namespace Tests.RegistrationTests
{
    public class BasicTest
    {
        [SetUp]
        public void StartTestWith()
        {
            SuperPage.InitializeJsonFile(10);
        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                SuperPage.TakeScreenShot();
            }
        }
    }
}
