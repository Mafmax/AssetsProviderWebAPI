using Mafmax.AssetsProvider.BLL.Services;
using Mafmax.AssetsProvider.DAL.Context;
using Mafmax.AssetsProvider.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.Mocks
{
    public static class MockFactory
    {
        private static DbContextOptions<APContext> dbContextOptions = new DbContextOptionsBuilder<APContext>().UseInMemoryDatabase("SameName").Options;
        public static APContext GetEmptyDbContext()
        {
            var db = new Mock<APContext>(dbContextOptions);
            return db.Object;
        }

        public static IIssuersService GetIssuersFactory()
        {
            var service = new Mock<IIssuersService>();
            return service.Object;
        }
        
        public static IEnumerable<APContext> GetAPContexts()
        {
            var db = new Mock<APContext>();
            return null;
        }


        public static IEnumerable<IEnumerable<Asset>> GetAssetsCombinations()
        {
            yield return new Asset[] 
            { 
            
            };
        }

    }
}
