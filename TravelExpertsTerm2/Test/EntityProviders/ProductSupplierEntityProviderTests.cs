// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System.Collections.Generic;
using System.Linq;
using TravelDatabase;
using Xunit;

namespace Test.EntityProviders
{
    [Devin]
    public class ProductSupplierEntityProviderTests : DatabaseTestingBase, IEqualityComparer<ProductSupplier>
    {
        // TODO: Test Add/Update/Delete & make sure it affects Packages_Products_Suppliers

        #region Tests

        [Fact]
        public void GetEntities()
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(_AllProductSuppliers, Database.ProductSuppliers.GetEntities(), this);
            }
        }

        [Theory]
        [MemberData(nameof(AllProductSuppliersParams))]
        public void GetEntityById(ProductSupplier productSupplier)
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(productSupplier, 
                    Database.ProductSuppliers.GetEntityById(productSupplier.ProductSupplierId), this);
            }
        }

        //[Theory]
        //[MemberData(nameof(AllProductSuppliersParams))]
        //public void Update(ProductSupplier productSupplier)
        //{
        //    lock (TestDatabaseLocker)
        //    {
        //        var modified = new ProductSupplier
        //        {
        //            // Should not update if the product/supplier Name is different than in the DB
        //        };
        //    }
        //}

        #endregion

        #region TestData

        private static readonly List<ProductSupplier> _AllProductSuppliers = new List<ProductSupplier>
        {
            new ProductSupplier { ProductSupplierId = 1, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 5492, Name = "SKYWAYS INTERNATIONAL" } },
            new ProductSupplier { ProductSupplierId = 2, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 6505, Name = "TRADE WINDS ASSOCIATES" } },
            new ProductSupplier { ProductSupplierId = 3, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 796, Name = "CYPRUS AIRWAYS LTD" } },
            new ProductSupplier { ProductSupplierId = 4, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 4196, Name = "TRAVEL STUDIO" } },
            new ProductSupplier { ProductSupplierId = 6, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 1040, Name = "EXECUTIVE SUITES" } },
            new ProductSupplier { ProductSupplierId = 7, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 3576, Name = "BLUE DANUBE HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 8, Product = new Product { ProductId = 3, Name = "Car rental" }, Supplier = new Supplier { SupplierId = 845, Name = "DISCOVER THE WORLD MARKET" } },
            new ProductSupplier { ProductSupplierId = 9, Product = new Product { ProductId = 7, Name = "Railroad" }, Supplier = new Supplier { SupplierId = 828, Name = "DER TRAVEL SERVICE LTD" } },
            new ProductSupplier { ProductSupplierId = 10, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 5777, Name = "TRAVEL BY RAIL" } },
            new ProductSupplier { ProductSupplierId = 11, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 5827, Name = "RESORT MARKETING INC" } },
            new ProductSupplier { ProductSupplierId = 12, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 3273, Name = "MARKETING AHEAD" } },
            new ProductSupplier { ProductSupplierId = 13, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 80, Name = "CHAT / TRAVELINE" } },
            new ProductSupplier { ProductSupplierId = 14, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 9396, Name = "SKYLINK TICKET CENTRE" } },
            new ProductSupplier { ProductSupplierId = 15, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 3589, Name = "G.A.P ADVENTURES INC." } },
            new ProductSupplier { ProductSupplierId = 16, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 69, Name = "NEW CONCEPTS - CANADA" } },
            new ProductSupplier { ProductSupplierId = 19, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 3376, Name = "MARTINAIR SERVICES" } },
            new ProductSupplier { ProductSupplierId = 20, Product = new Product { ProductId = 3, Name = "Car rental" }, Supplier = new Supplier { SupplierId = 323, Name = "COMPAGNIA ITALIANA TURISM" } },
            new ProductSupplier { ProductSupplierId = 23, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 3549, Name = "BONANZA HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 24, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 1918, Name = "MARKET SQUARE TOURS" } },
            new ProductSupplier { ProductSupplierId = 25, Product = new Product { ProductId = 3, Name = "Car rental" }, Supplier = new Supplier { SupplierId = 11156, Name = "ALITOURS INTERNATIONAL INC." } },
            new ProductSupplier { ProductSupplierId = 26, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 8837, Name = "SCANDITOURS" } },
            new ProductSupplier { ProductSupplierId = 28, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 8089, Name = "EXCLUSIVE TOURS" } },
            new ProductSupplier { ProductSupplierId = 29, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 1028, Name = "EUROP-AUTO-VACANCES/HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 30, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 2466, Name = "PLANET FRANCE/PLANET EURO" } },
            new ProductSupplier { ProductSupplierId = 31, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 1406, Name = "EUROCRUISES INC." } },
            new ProductSupplier { ProductSupplierId = 32, Product = new Product { ProductId = 3, Name = "Car rental" }, Supplier = new Supplier { SupplierId = 1416, Name = "THE HOLIDAY NETWORK" } },
            new ProductSupplier { ProductSupplierId = 33, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 13596, Name = "A & TIC SUPPORT INC." } },
            new ProductSupplier { ProductSupplierId = 34, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 9323, Name = "BONAVE" } },
            new ProductSupplier { ProductSupplierId = 35, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 11237, Name = "DKM COACH LINES LTD" } },
            new ProductSupplier { ProductSupplierId = 36, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 9785, Name = "MANDITOURS INTL INC." } },
            new ProductSupplier { ProductSupplierId = 37, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 11163, Name = "D-TOUR MARKETING" } },
            new ProductSupplier { ProductSupplierId = 39, Product = new Product { ProductId = 9, Name = "Travel Insurance" }, Supplier = new Supplier { SupplierId = 11172, Name = "MERIT TRAVEL GROUP INC." } },
            new ProductSupplier { ProductSupplierId = 40, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 9285, Name = "JTB INTERNATIONAL (CANADA)" } },
            new ProductSupplier { ProductSupplierId = 41, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 3622, Name = "CHINA TRAVEL SERVICE (CAN)" } },
            new ProductSupplier { ProductSupplierId = 42, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 9323, Name = "BONAVE" } },
            new ProductSupplier { ProductSupplierId = 43, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 1766, Name = "KLM ROYAL DUTCH AIRLINES" } },
            new ProductSupplier { ProductSupplierId = 44, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 3212, Name = "TREK HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 45, Product = new Product { ProductId = 9, Name = "Travel Insurance" }, Supplier = new Supplier { SupplierId = 11174, Name = "GRUPO TACA" } },
            new ProductSupplier { ProductSupplierId = 46, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 3600, Name = "GOLDEN ESCAPES" } },
            new ProductSupplier { ProductSupplierId = 47, Product = new Product { ProductId = 9, Name = "Travel Insurance" }, Supplier = new Supplier { SupplierId = 11160, Name = "TOTAL ADVANTAGE TRAVEL" } },
            new ProductSupplier { ProductSupplierId = 48, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 11549, Name = "GO ACTIVE VACATIONS" } },
            new ProductSupplier { ProductSupplierId = 49, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 2827, Name = "SOUTH WIND TOURS LTD." } },
            new ProductSupplier { ProductSupplierId = 50, Product = new Product { ProductId = 9, Name = "Travel Insurance" }, Supplier = new Supplier { SupplierId = 12657, Name = "SAAAI TRAVEL INC." } },
            new ProductSupplier { ProductSupplierId = 51, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 7377, Name = "MAJESTIC TOURS" } },
            new ProductSupplier { ProductSupplierId = 52, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 6550, Name = "LTI TOURS" } },
            new ProductSupplier { ProductSupplierId = 53, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 1634, Name = "ISLANDS IN THE SUN CRUISE" } },
            new ProductSupplier { ProductSupplierId = 54, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 2140, Name = "NAGEL TOURS LTD" } },
            new ProductSupplier { ProductSupplierId = 55, Product = new Product { ProductId = 3, Name = "Car rental" }, Supplier = new Supplier { SupplierId = 317, Name = "BLYTH & COMPANY TRAVEL" } },
            new ProductSupplier { ProductSupplierId = 56, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 1205, Name = "GOLDMAN MARKETING" } },
            new ProductSupplier { ProductSupplierId = 57, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 3633, Name = "VIP INTERNATIONAL" } },
            new ProductSupplier { ProductSupplierId = 58, Product = new Product { ProductId = 2, Name = "Attractions" }, Supplier = new Supplier { SupplierId = 6873, Name = "BIMAN BANGLADESH AIRLINES" } },
            new ProductSupplier { ProductSupplierId = 59, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 7377, Name = "MAJESTIC TOURS" } },
            new ProductSupplier { ProductSupplierId = 60, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 7244, Name = "WORLD ACCESS MARKETING" } },
            new ProductSupplier { ProductSupplierId = 61, Product = new Product { ProductId = 3, Name = "Car rental" }, Supplier = new Supplier { SupplierId = 2938, Name = "SUN & LEISURE TRAVEL CORP." } },
            new ProductSupplier { ProductSupplierId = 63, Product = new Product { ProductId = 2, Name = "Attractions" }, Supplier = new Supplier { SupplierId = 5081, Name = "ANHEUSER-BUSCH ADVENTURE" } },
            new ProductSupplier { ProductSupplierId = 64, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 3119, Name = "MEDIAN AVIATION RESOURCES" } },
            new ProductSupplier { ProductSupplierId = 65, Product = new Product { ProductId = 9, Name = "Travel Insurance" }, Supplier = new Supplier { SupplierId = 2998, Name = "ALIOTOURS" } },
            new ProductSupplier { ProductSupplierId = 66, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 3576, Name = "BLUE DANUBE HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 67, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 2592, Name = "ESPRIT/SERVICENTRE HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 68, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 100, Name = "AVILA TOURS INC." } },
            new ProductSupplier { ProductSupplierId = 69, Product = new Product { ProductId = 9, Name = "Travel Insurance" }, Supplier = new Supplier { SupplierId = 2987, Name = "TOURCAN VACATIONS INC" } },
            new ProductSupplier { ProductSupplierId = 70, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 1005, Name = "ENCORE CRUISES" } },
            new ProductSupplier { ProductSupplierId = 71, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 908, Name = "ELITE ORIENT TOURS INC." } },
            new ProductSupplier { ProductSupplierId = 72, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 5796, Name = "REPWORLD INC." } },
            new ProductSupplier { ProductSupplierId = 73, Product = new Product { ProductId = 10, Name = "Yacht/Boat Charters" }, Supplier = new Supplier { SupplierId = 2386, Name = "PAVLIK TRAVEL GROUP" } },
            new ProductSupplier { ProductSupplierId = 74, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 3650, Name = "CUNARD LINES" } },
            new ProductSupplier { ProductSupplierId = 75, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 1425, Name = "HOLLAND AMERICA LINE WEST" } },
            new ProductSupplier { ProductSupplierId = 76, Product = new Product { ProductId = 8, Name = "Tours" }, Supplier = new Supplier { SupplierId = 6346, Name = "PASSAGES EXPEDITIONS" } },
            new ProductSupplier { ProductSupplierId = 78, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 1685, Name = "GOWAY TRAVEL LTD." } },
            new ProductSupplier { ProductSupplierId = 79, Product = new Product { ProductId = 2, Name = "Attractions" }, Supplier = new Supplier { SupplierId = 2588, Name = "UNIQUE VACATIONS (CANADA)" } },
            new ProductSupplier { ProductSupplierId = 80, Product = new Product { ProductId = 6, Name = "Motor Coach" }, Supplier = new Supplier { SupplierId = 1620, Name = "INTAIR VACATIONS" } },
            new ProductSupplier { ProductSupplierId = 81, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 1542, Name = "INSIGHT VACATIONS CANADA" } },
            new ProductSupplier { ProductSupplierId = 82, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 9766, Name = "KINTETSU INTERNATIONAL" } },
            new ProductSupplier { ProductSupplierId = 83, Product = new Product { ProductId = 5, Name = "Hotel" }, Supplier = new Supplier { SupplierId = 5228, Name = "THE RMR GROUP INC" } },
            new ProductSupplier { ProductSupplierId = 84, Product = new Product { ProductId = 6, Name = "Motor Coach" }, Supplier = new Supplier { SupplierId = 9396, Name = "SKYLINK TICKET CENTRE" } },
            new ProductSupplier { ProductSupplierId = 87, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 1859, Name = "LOTUS HOLIDAYS" } },
            new ProductSupplier { ProductSupplierId = 90, Product = new Product { ProductId = 1, Name = "Air" }, Supplier = new Supplier { SupplierId = 1713, Name = "JETPACIFIC HOLIDAYS INC" } },
            new ProductSupplier { ProductSupplierId = 93, Product = new Product { ProductId = 4, Name = "Cruise" }, Supplier = new Supplier { SupplierId = 3650, Name = "CUNARD LINES" } }
        };

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> AllProductSuppliersParams
            => _AllProductSuppliers.Select(ps => new object[] {ps});

        #endregion

        #region IEqualityComparer<ProductSupplier>

        public bool Equals(ProductSupplier x, ProductSupplier y)
        {
            return x.ProductSupplierId == y.ProductSupplierId &&
                   x.Product?.ProductId == y.Product?.ProductId &&
                   x.Product?.Name == y.Product?.Name &&
                   x.Supplier?.SupplierId == y.Supplier?.SupplierId &&
                   x.Supplier?.Name == y.Supplier?.Name;
        }

        public int GetHashCode(ProductSupplier obj)
        {
            return obj.ProductSupplierId.GetHashCode() * 17 +
                   obj.Product?.ProductId.GetHashCode() ?? 0 * 17 +
                   obj.Product?.Name?.GetHashCode() ?? 0 * 17 +
                   obj.Supplier?.SupplierId.GetHashCode() ?? 0 *17 +
                   obj.Supplier?.Name?.GetHashCode() ?? 0;
        }

        #endregion

    }
}
