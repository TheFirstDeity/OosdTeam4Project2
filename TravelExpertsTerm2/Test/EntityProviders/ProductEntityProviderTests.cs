// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using TravelDatabase;
using Xunit;

// ReSharper disable MemberCanBePrivate.Global
namespace Test.EntityProviders
{
    [Devin]
    [NoReorder]
    public class ProductEntityProviderTests : DatabaseTestingBase, IEqualityComparer<Product>
    {

        #region Tests

        [Fact]
        public void GetEntities()
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(_AllProducts, Database.Products.GetEntities(), this);
            }
        }

        [Fact]
        public void GetEntities_ToList()
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(_AllProducts, Database.Products.GetEntities().ToList(), this);
            }
        }

        [Theory]
        [MemberData(nameof(AllProductsTestData))]
        public void GetEntityById(Product product)
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(product, Database.Products.GetEntityById(product.ProductId), this);
            }
        }

        [Theory]
        [InlineData(666)]
        [InlineData(777)]
        [InlineData(888)]
        [InlineData(999)]
        [InlineData(1111)]
        public void GetEntityById_NullForNonExistentId(int id)
        {
            lock (TestDatabaseLocker)
            {
                Assert.Null(Database.Products.GetEntityById(id));
            }
        }

        [Fact]
        public void AddThenDeleteEntity()
        {
            lock (TestDatabaseLocker)
            {
                var product = new Product
                {
                    ProductId = NextAddedIdentity("Products"), // next ID
                    Name = "TEST_OBJECT"
                };

                Assert.Null(Database.Products.GetEntityById(product.ProductId)); // nexy ID doesn't exist
                Assert.Equal(product.ProductId, Database.Products.AddEntity(product)); // add returns new ID
                Assert.Equal(product, Database.Products.GetEntityById(product.ProductId), this); // check does exist
                Assert.True(Database.Products.DeleteEntity(product)); // delete returns success
                Assert.Null(Database.Products.GetEntityById(product.ProductId)); // check doesn't exist
            }
        }

        [Theory]
        [MemberData(nameof(AllProductsTestData))]
        public void UpdateEntity(Product product)
        {
            lock (TestDatabaseLocker)
            {
                var modified = new Product
                {
                    ProductId = product.ProductId,
                    Name = "FISH"
                };

                // Set to FISH
                Assert.True(Database.Products.UpdateEntity(modified));
                Assert.Equal(modified, Database.Products.GetEntityById(modified.ProductId), this);

                // Set to original value
                Assert.True(Database.Products.UpdateEntity(product));
                Assert.Equal(product, Database.Products.GetEntityById(product.ProductId), this);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void ArgumentNullException()
        {
            lock (TestDatabaseLocker)
            {
                Assert.Throws<ArgumentNullException>(() => Database.Products.AddEntity(null));
                Assert.Throws<ArgumentNullException>(() => Database.Products.DeleteEntity(null));
                Assert.Throws<ArgumentNullException>(() => Database.Products.UpdateEntity(null));
            }
        }

        [Fact]
        public void ArgumentRangeException() // Product table only
        {
            lock (TestDatabaseLocker)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => Database.Products.GetEntityById(-1));
            }
        }

        #endregion

        #region Test Data

        public static IEnumerable<object[]> AllProductsTestData
            => _AllProducts.Select(product => new object[] { product });

        private static readonly List<Product> _AllProducts 
            = new List<Product>
            {
                new Product {ProductId = 1, Name = "Air"},
                new Product {ProductId = 2, Name = "Attractions"},
                new Product {ProductId = 3, Name = "Car rental"},
                new Product {ProductId = 4, Name = "Cruise"},
                new Product {ProductId = 5, Name = "Hotel"},
                new Product {ProductId = 6, Name = "Motor Coach"},
                new Product {ProductId = 7, Name = "Railroad"},
                new Product {ProductId = 8, Name = "Tours"},
                new Product {ProductId = 9, Name = "Travel Insurance"},
                new Product {ProductId = 10, Name = "Yacht/Boat Charters"}
            };

        #endregion

        #region IEqualityComparer<Product>

        bool IEqualityComparer<Product>.Equals(Product x, Product y)
        {
            return x.ProductId == y.ProductId && x.Name == y.Name;
        }

        int IEqualityComparer<Product>.GetHashCode(Product obj)
        {
            return obj.Name?.GetHashCode() ?? 0 * 17 + obj.ProductId.GetHashCode();
        }

        #endregion

    }
}
