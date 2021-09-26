using Mafmax.AssetsProvider.Main.Controllers;
using Mafmax.AssetsProvider.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mafmax.AssetsProvider.Main.Tests
{
    public class IssuerControllerTests
    {
        [Fact]
        public void TestTest()
        {
            //Arrange
            var db = MockFactory.GetEmptyDbContext();
            var service = MockFactory.GetIssuersFactory();

            //Act

            //Asset

        }
        
    }
}
