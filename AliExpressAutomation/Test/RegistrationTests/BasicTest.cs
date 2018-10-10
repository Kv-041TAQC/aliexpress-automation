using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests.RegistrationTests
{
    public class BasicTest
    {
        [SetUp]
        public void StartTestWith()
        {

        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {

            }
        }
    }
}
