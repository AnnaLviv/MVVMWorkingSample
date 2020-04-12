using MVVM.Model;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MVVM.Core.Test
{
    public class OwnerInfoServiceTests
    {
        IOwnerInfoService service;

        [OneTimeSetUp]
        public void SetUp()
        {
            service = new OwnerInfoService();
        }

        [TestCase("AnnaLviv","Anna", false, TestName ="Not owner")]
        [TestCase("AnnaLvivTest", "AnnaTest", true, TestName = "Owner")]
        public async Task IsOwnerAsyncTest(string userName, string greetingName, bool expectedResult)
        {
            var inputOwnerInfo = new OwnerInfo(userName, greetingName);
            var result = await service.IsOwnerAsync(inputOwnerInfo);
            Assert.AreEqual(expectedResult, result);
        }
    }
}