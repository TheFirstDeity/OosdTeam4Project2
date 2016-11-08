// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using JetBrains.Annotations;
using TravelDatabase;
using TravelDatabase.EntityProviders;
using Xunit;

namespace Test.EntityProviders
{
    [Devin]
    public class DatabaseTests : DatabaseTestingBase
    {
        // TODO: make "ConnectionStringFilePath" a settable public property, test whether non-existent file returns null

        [Fact]
        public void PackageProvider_Initialized()
        {
            Assert.NotNull(Database.Packages);
            Assert.IsAssignableFrom<EntityProviderBase<Package>>(Database.Packages);
        }

        [Fact]
        public void ProductProvider_Initialized()
        {
            Assert.NotNull(Database.Products);
            Assert.IsAssignableFrom<EntityProviderBase<Product>>(Database.Products);
        }

        // TODO: tests for Internal Helpers (need a contitional compile which exposes them for testing)
        #region Internal Helpers

        //[Theory]
        //[InlineData("Agencies", 2)]
        //public void GetLastAssignedId(string tableName, int id)
        //{

        //}

        //[Theory]
        //[InlineData("Agencies", 1)]
        //public void GetIdIncrementer(string tableName, int id)
        //{

        //}

        //[Theory]
        //[InlineData("Agencies", 3)]
        //public void GetNextAssignedId(string tableName, int id)
        //{

        //}

        #endregion

    }
}
