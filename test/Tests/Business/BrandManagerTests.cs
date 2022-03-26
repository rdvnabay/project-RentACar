using DataAccess.Abstract;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BrandManagerTests
    {
        private Mock<IBrandRepository> _brandDal;

        [SetUp]
        public void Setup()
        {
            _brandDal = new Mock<IBrandRepository>();
   
    }
        [Test]
        public void Get_All_Brand()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
