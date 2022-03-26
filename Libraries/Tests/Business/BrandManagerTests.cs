using DataAccess.Abstract;
using Entities.Dtos;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
          
        }
    }
}
