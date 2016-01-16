﻿// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TravelDatabase;
using Xunit;

namespace Test.EntityProviders
{
    public class PackageEntityProviderTests : DatabaseTestingBase, IEqualityComparer<Package>
    {

        #region Tests

        [Fact]
        public void GetAll()
        {
            var actual = Database.PackageProvider.GetEntities();
            Assert.Equal(AllPackagesNoChildrenList, actual, this);
        }

        [Fact]
        public void GetAll_Cascade()
        {
            var actual = Database.PackageProvider.Cascade.GetEntities();
            Assert.Equal(AllPackagesList, actual, this);
        }

        [Theory]
        [MemberData(nameof(AllPackagesNoChildrenParams))]
        public void GetById(Package expected)
        {
            var actual = Database.PackageProvider.GetEntityById(expected.PackageId);
            Assert.Equal(expected, actual, this);
        }

        [Theory]
        [MemberData(nameof(AllPackagesParams))]
        public void GetById_Cascade(Package expected)
        {
            var actual = Database.PackageProvider.Cascade.GetEntityById(expected.PackageId);
            Assert.Equal(expected, actual, this);
        }

        [Theory]
        [MemberData(nameof(AllPackagesNoChildrenParams))]
        public void GetById_CascadeDoesntPersistToNextCall(Package expected)
        {
            var cas = Database.PackageProvider.Cascade;
            var actual = Database.PackageProvider.GetEntityById(expected.PackageId);
            Assert.Equal(expected, actual, this);
        }

        [Theory]
        [MemberData(nameof(AllPackagesParams))]
        public void GetById_MultipleCascadeCallsDoesntAffectResult(Package expected)
        {
            var actual = Database.PackageProvider
                .Cascade.Cascade.Cascade
                .GetEntityById(expected.PackageId);

            Assert.Equal(expected, actual, this);
        }

        [Theory]
        [InlineData(666)]
        [InlineData(777)]
        [InlineData(888)]
        [InlineData(999)]
        [InlineData(1111)]
        public void GetEntityById_NullForNonExistentId(int id)
        {
            Assert.Null(Database.PackageProvider.GetEntityById(id));
        }

        [Theory]
        [InlineData(666)]
        [InlineData(777)]
        [InlineData(888)]
        [InlineData(999)]
        [InlineData(1111)]
        public void GetEntityById_NullForNonExistentId_Cascade(int id)
        {
            Assert.Null(Database.PackageProvider.Cascade.GetEntityById(id));
        }

        //[Theory]
        //[MemberData(nameof(FakePackagesParams))]
        //public void AddReadDeletePackage_Cascade(Package newEntity)
        //{
        //    Assert.True(newEntity.PackageId < 0); // ID starts invalid
        //    var newId = NextAddedIdentity("Packages");

        //    Assert.Equal(newId, Database.PackageProvider.Cascade.AddEntity(newEntity)); // Add returns the new ID
        //    newEntity.PackageId = newId; // Set ID to make it equal to the one in the database

        //    Assert.Equal(newEntity, Database.PackageProvider.Cascade.GetEntityById(newId)); // Read new entity from database
        //    Assert.True(Database.PackageProvider.Cascade.DeleteEntity(newEntity)); // Delete new entity from database
        //    Assert.Null(Database.PackageProvider.Cascade.GetEntityById(newId)); // Verify entity is deleted
        //}

        #endregion

        #region Test Data

        private static IEnumerable<Package> AllPackagesList { get; } 
            = AllPackagesParams.Select(o => (Package) o[0]);

        private static IEnumerable<Package> AllPackagesNoChildrenList { get; }
            = AllPackagesNoChildrenParams.Select(o => (Package)o[0]);

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> AllPackagesParams
        {
            get
            {
                yield return new object[]
                {
                    new Package
                    {
                        PackageId = 1,
                        Name = "Caribbean New Year",
                        StartDate = DateTime.Parse("2005-12-25 00:00:00.000"),
                        EndDate = DateTime.Parse("2006-01-04 00:00:00.000"),
                        Description = "Cruise the Caribbean & Celebrate the New Year.",
                        BasePrice = 4800M,
                        AgencyCommission = 400M,
                        ProductSuppliers =
                        {
                            new ProductSupplier
                            {
                                ProductSupplierId = 65,
                                Product = new Product {ProductId = 9, Name = "Travel Insurance"},
                                Supplier = new Supplier {SupplierId = 2998, Name = "ALIOTOURS"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 93,
                                Product = new Product {ProductId = 4, Name = "Cruise"},
                                Supplier = new Supplier {SupplierId = 3650, Name = "CUNARD LINES"}
                            }
                        }
                    }
                };

                yield return new object[]
                {
                    new Package
                    {
                        PackageId = 2,
                        Name = "Polynesian Paradise",
                        StartDate = DateTime.Parse("2005-12-12 00:00:00.000"),
                        EndDate = DateTime.Parse("2005-12-20 00:00:00.000"),
                        Description = "8 Day All Inclusive Hawaiian Vacation",
                        BasePrice = 3000M,
                        AgencyCommission = 310M,
                        ProductSuppliers =
                        {
                            new ProductSupplier
                            {
                                ProductSupplierId = 32,
                                Product = new Product {ProductId = 3, Name = "Car rental"},
                                Supplier = new Supplier {SupplierId = 1416, Name = "THE HOLIDAY NETWORK"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 33,
                                Product = new Product {ProductId = 5, Name = "Hotel"},
                                Supplier = new Supplier {SupplierId = 13596, Name = "A & TIC SUPPORT INC."}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 90,
                                Product = new Product {ProductId = 1, Name = "Air"},
                                Supplier = new Supplier {SupplierId = 1713, Name = "JETPACIFIC HOLIDAYS INC"}
                            }
                        }
                    }
                };

                yield return new object[]
                {
                    new Package
                    {
                        PackageId = 3,
                        Name = "Asian Expedition",
                        StartDate = DateTime.Parse("2006-05-14 00:00:00.000"),
                        EndDate = DateTime.Parse("2006-05-28 00:00:00.000"),
                        Description = "Airfaire, Hotel and Eco Tour.",
                        BasePrice = 2800M,
                        AgencyCommission = 300M,
                        ProductSuppliers =
                        {
                            new ProductSupplier
                            {
                                ProductSupplierId = 28,
                                Product = new Product {ProductId = 8, Name = "Tours"},
                                Supplier = new Supplier {SupplierId = 8089, Name = "EXCLUSIVE TOURS"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 82,
                                Product = new Product {ProductId = 5, Name = "Hotel"},
                                Supplier = new Supplier {SupplierId = 9766, Name = "KINTETSU INTERNATIONAL"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 87,
                                Product = new Product {ProductId = 1, Name = "Air"},
                                Supplier = new Supplier {SupplierId = 1859, Name = "LOTUS HOLIDAYS"}
                            }
                        }
                    }
                };

                yield return new object[]
                {
                    new Package
                    {
                        PackageId = 4,
                        Name = "European Vacation",
                        StartDate = DateTime.Parse("2005-11-01 00:00:00.000"),
                        EndDate = DateTime.Parse("2005-11-14 00:00:00.000"),
                        Description = "Euro Tour with Rail Pass and Travel Insurance",
                        BasePrice = 3000M,
                        AgencyCommission = 280M,
                        ProductSuppliers =
                        {
                            new ProductSupplier
                            {
                                ProductSupplierId = 9,
                                Product = new Product {ProductId = 7, Name = "Railroad"},
                                Supplier = new Supplier {SupplierId = 828, Name = "DER TRAVEL SERVICE LTD"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 65,
                                Product = new Product {ProductId = 9, Name = "Travel Insurance"},
                                Supplier = new Supplier {SupplierId = 2998, Name = "ALIOTOURS"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 84,
                                Product = new Product {ProductId = 6, Name = "Motor Coach"},
                                Supplier = new Supplier {SupplierId = 9396, Name = "SKYLINK TICKET CENTRE"}
                            }
                        }
                    }
                };

            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> AllPackagesNoChildrenParams
        {
            get
            {
                foreach (var package in AllPackagesParams.Select(o => (Package)o[0]))
                {
                    package.ProductSuppliers.Clear();
                    yield return new object[] { package };
                }
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> FakePackagesParams
        {
            get
            {
                // Case: Fake Package with no ProductSuppliers
                yield return new object[]
                {
                    new Package
                    {
                        PackageId = -1,
                        Name = "Go To Hell",
                        StartDate = DateTime.Parse("2016-01-01 00:00:00.000"),
                        EndDate = DateTime.Parse("2016-02-02 00:00:00.000"),
                        Description = "FISH WITH THIS TEST-PACKAGE DESCRIPTION",
                        BasePrice = 6666M,
                        AgencyCommission = 666M
                    }
                };

                // Case: Fake Package with existing ProductSupplier
                yield return new object[]
                {
                    new Package
                    {
                        PackageId = -1,
                        Name = "Go To Hell",
                        StartDate = DateTime.Parse("2016-01-01 00:00:00.000"),
                        EndDate = DateTime.Parse("2016-02-02 00:00:00.000"),
                        Description = "FISH WITH THIS TEST-PACKAGE DESCRIPTION",
                        BasePrice = 6666M,
                        AgencyCommission = 666M,
                        ProductSuppliers =
                        {
                            new ProductSupplier
                            {
                                ProductSupplierId = 65,
                                Product = new Product {ProductId = 9, Name = "Travel Insurance"},
                                Supplier = new Supplier {SupplierId = 2998, Name = "ALIOTOURS"}
                            }
                        }
                    }
                };

                // Case: Fake Package with two existing ProductSuppliers
                yield return new object[]
                {
                    new Package
                    {
                        PackageId = -1,
                        Name = "Go To Hell",
                        StartDate = DateTime.Parse("2016-01-01 00:00:00.000"),
                        EndDate = DateTime.Parse("2016-02-02 00:00:00.000"),
                        Description = "FISH WITH THIS TEST-PACKAGE DESCRIPTION",
                        BasePrice = 6666M,
                        AgencyCommission = 666M,
                        ProductSuppliers =
                        {
                            new ProductSupplier
                            {
                                ProductSupplierId = 65,
                                Product = new Product {ProductId = 9, Name = "Travel Insurance"},
                                Supplier = new Supplier {SupplierId = 2998, Name = "ALIOTOURS"}
                            },
                            new ProductSupplier
                            {
                                ProductSupplierId = 93,
                                Product = new Product {ProductId = 4, Name = "Cruise"},
                                Supplier = new Supplier {SupplierId = 3650, Name = "CUNARD LINES"}
                            }
                        }
                    }
                };


                // Fake Package with non-existent ProductSupplier
                // Fake Package with ProductSupplier new Product/Supplier
                // (exception) Fake Package with ProductSupplier and null Product/Supplier

            }
        }

        #endregion

        #region IEqualityComparer<Package>

        bool IEqualityComparer<Package>.Equals(Package x, Package y)
        {
            if (!(
                x.PackageId == y.PackageId
                && x.Name == y.Name
                && x.StartDate == y.StartDate
                && x.EndDate == y.EndDate
                && x.Description == y.Description
                && Math.Abs(x.BasePrice - y.BasePrice) < 0.005M
                && Math.Abs(x.AgencyCommission - y.AgencyCommission) < 0.005M
                && x.ProductSuppliers.Count == y.ProductSuppliers.Count))
                return false;

            // Look for some ProductSupplier where not all fields in x equal
            // all fields in y. If none are found, both sequences are equal.
            return !x.ProductSuppliers.Where((t, i) => !(
                t.ProductSupplierId == y.ProductSuppliers[i].ProductSupplierId 
                && t.Product?.ProductId == y.ProductSuppliers[i].Product?.ProductId 
                && t.Product?.Name == y.ProductSuppliers[i].Product?.Name 
                && t.Supplier?.SupplierId == y.ProductSuppliers[i].Supplier?.SupplierId 
                && t.Supplier?.Name == y.ProductSuppliers[i].Supplier?.Name))
                .Any();
        }

        int IEqualityComparer<Package>.GetHashCode(Package obj)
        {
            return obj.PackageId.GetHashCode();
        }

        #endregion

    }
}
