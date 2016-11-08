// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TravelDatabase;
using Xunit;

namespace Test.EntityProviders
{
    [Devin]
    public class SupplierEntityProviderTests : DatabaseTestingBase, IEqualityComparer<Supplier>
    {

        #region Tests

        [Fact]
        public void GetEntities()
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(AllSuppliers, Database.Suppliers.GetEntities(), this);
            }
        }

        [Theory]
        [MemberData(nameof(AllSuppliersParams))]
        public void GetEntityById(Supplier supplier)
        {
            lock (TestDatabaseLocker)
            {
                Assert.Equal(supplier, Database.Suppliers.GetEntityById(supplier.SupplierId), this);
            }
        }

        [Theory]
        [InlineData(66666)]
        [InlineData(77777)]
        [InlineData(88888)]
        [InlineData(99999)]
        [InlineData(111111)]
        public void GetEntityById_NullForNonExistentId(int id)
        {
            lock (TestDatabaseLocker)
            {
                Assert.Null(Database.Suppliers.GetEntityById(id));
            }
        }

        [Theory]
        [InlineData(66665, "TEST Super Supplier")]
        [InlineData(77776, "TEST WestJet")]
        [InlineData(88887, "TEST Space Camp")]
        [InlineData(99998, "TEST Big Island Resteraunt")]
        [InlineData(111110, "TEST Monadone")]
        public void AddThenDeleteEntity(int supId, string supName)
        {
            lock (TestDatabaseLocker)
            {
                var supplier = new Supplier
                {
                    SupplierId = supId,
                    Name = supName
                };

                Assert.Null(Database.Suppliers.GetEntityById(supplier.SupplierId)); // next ID doesn't exist
                Assert.Equal(supplier.SupplierId, Database.Suppliers.AddEntity(supplier)); // add returns new ID
                Assert.Equal(supplier, Database.Suppliers.GetEntityById(supplier.SupplierId), this); // check does exist
                Assert.True(Database.Suppliers.DeleteEntity(supplier)); // delete returns success
                Assert.Null(Database.Suppliers.GetEntityById(supplier.SupplierId)); // check doesn't exist
            }
        }

        [Theory]
        [MemberData(nameof(AllSuppliersParams))]
        public void UpdateEntity(Supplier supplier)
        {
            lock (TestDatabaseLocker)
            {
                var modified = new Supplier
                {
                    SupplierId = supplier.SupplierId,
                    Name = "FISH"
                };

                // Set to FISH
                Assert.True(Database.Suppliers.UpdateEntity(modified));
                Assert.Equal(modified, Database.Suppliers.GetEntityById(supplier.SupplierId), this);

                // Set to original value
                Assert.True(Database.Suppliers.UpdateEntity(supplier));
                Assert.Equal(supplier, Database.Suppliers.GetEntityById(modified.SupplierId), this);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void ArgumentNullException()
        {
            lock (TestDatabaseLocker)
            {
                Assert.Throws<ArgumentNullException>(() => Database.Suppliers.AddEntity(null));
                Assert.Throws<ArgumentNullException>(() => Database.Suppliers.DeleteEntity(null));
                Assert.Throws<ArgumentNullException>(() => Database.Suppliers.UpdateEntity(null));
            }
        }

        #endregion

        #region Test Data

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> AllSuppliersParams => AllSuppliers.Select(s => new object[] {s});

        private static IEnumerable<Supplier> AllSuppliers { get; }
            = new List<Supplier>
            {
                new Supplier {SupplierId = 69, Name = "NEW CONCEPTS - CANADA"},
                new Supplier {SupplierId = 80, Name = "CHAT / TRAVELINE"},
                new Supplier {SupplierId = 100, Name = "AVILA TOURS INC."},
                new Supplier {SupplierId = 317, Name = "BLYTH & COMPANY TRAVEL"},
                new Supplier {SupplierId = 323, Name = "COMPAGNIA ITALIANA TURISM"},
                new Supplier {SupplierId = 796, Name = "CYPRUS AIRWAYS LTD"},
                new Supplier {SupplierId = 828, Name = "DER TRAVEL SERVICE LTD"},
                new Supplier {SupplierId = 845, Name = "DISCOVER THE WORLD MARKET"},
                new Supplier {SupplierId = 908, Name = "ELITE ORIENT TOURS INC."},
                new Supplier {SupplierId = 1005, Name = "ENCORE CRUISES"},
                new Supplier {SupplierId = 1028, Name = "EUROP-AUTO-VACANCES/HOLIDAYS"},
                new Supplier {SupplierId = 1040, Name = "EXECUTIVE SUITES"},
                new Supplier {SupplierId = 1205, Name = "GOLDMAN MARKETING"},
                new Supplier {SupplierId = 1406, Name = "EUROCRUISES INC."},
                new Supplier {SupplierId = 1416, Name = "THE HOLIDAY NETWORK"},
                new Supplier {SupplierId = 1425, Name = "HOLLAND AMERICA LINE WEST"},
                new Supplier {SupplierId = 1542, Name = "INSIGHT VACATIONS CANADA"},
                new Supplier {SupplierId = 1620, Name = "INTAIR VACATIONS"},
                new Supplier {SupplierId = 1634, Name = "ISLANDS IN THE SUN CRUISE"},
                new Supplier {SupplierId = 1685, Name = "GOWAY TRAVEL LTD."},
                new Supplier {SupplierId = 1713, Name = "JETPACIFIC HOLIDAYS INC"},
                new Supplier {SupplierId = 1766, Name = "KLM ROYAL DUTCH AIRLINES"},
                new Supplier {SupplierId = 1859, Name = "LOTUS HOLIDAYS"},
                new Supplier {SupplierId = 1918, Name = "MARKET SQUARE TOURS"},
                new Supplier {SupplierId = 2140, Name = "NAGEL TOURS LTD"},
                new Supplier {SupplierId = 2386, Name = "PAVLIK TRAVEL GROUP"},
                new Supplier {SupplierId = 2466, Name = "PLANET FRANCE/PLANET EURO"},
                new Supplier {SupplierId = 2588, Name = "UNIQUE VACATIONS (CANADA)"},
                new Supplier {SupplierId = 2592, Name = "ESPRIT/SERVICENTRE HOLIDAYS"},
                new Supplier {SupplierId = 2827, Name = "SOUTH WIND TOURS LTD."},
                new Supplier {SupplierId = 2938, Name = "SUN & LEISURE TRAVEL CORP."},
                new Supplier {SupplierId = 2987, Name = "TOURCAN VACATIONS INC"},
                new Supplier {SupplierId = 2998, Name = "ALIOTOURS"},
                new Supplier {SupplierId = 3119, Name = "MEDIAN AVIATION RESOURCES"},
                new Supplier {SupplierId = 3212, Name = "TREK HOLIDAYS"},
                new Supplier {SupplierId = 3273, Name = "MARKETING AHEAD"},
                new Supplier {SupplierId = 3376, Name = "MARTINAIR SERVICES"},
                new Supplier {SupplierId = 3549, Name = "BONANZA HOLIDAYS"},
                new Supplier {SupplierId = 3576, Name = "BLUE DANUBE HOLIDAYS"},
                new Supplier {SupplierId = 3589, Name = "G.A.P ADVENTURES INC."},
                new Supplier {SupplierId = 3600, Name = "GOLDEN ESCAPES"},
                new Supplier {SupplierId = 3622, Name = "CHINA TRAVEL SERVICE (CAN)"},
                new Supplier {SupplierId = 3633, Name = "VIP INTERNATIONAL"},
                new Supplier {SupplierId = 3650, Name = "CUNARD LINES"},
                new Supplier {SupplierId = 4196, Name = "TRAVEL STUDIO"},
                new Supplier {SupplierId = 5081, Name = "ANHEUSER-BUSCH ADVENTURE"},
                new Supplier {SupplierId = 5228, Name = "THE RMR GROUP INC"},
                new Supplier {SupplierId = 5492, Name = "SKYWAYS INTERNATIONAL"},
                new Supplier {SupplierId = 5777, Name = "TRAVEL BY RAIL"},
                new Supplier {SupplierId = 5796, Name = "REPWORLD INC."},
                new Supplier {SupplierId = 5827, Name = "RESORT MARKETING INC"},
                new Supplier {SupplierId = 5857, Name = "TOURS OF EXPLORATION"},
                new Supplier {SupplierId = 6346, Name = "PASSAGES EXPEDITIONS"},
                new Supplier {SupplierId = 6505, Name = "TRADE WINDS ASSOCIATES"},
                new Supplier {SupplierId = 6550, Name = "LTI TOURS"},
                new Supplier {SupplierId = 6873, Name = "BIMAN BANGLADESH AIRLINES"},
                new Supplier {SupplierId = 7244, Name = "WORLD ACCESS MARKETING"},
                new Supplier {SupplierId = 7377, Name = "MAJESTIC TOURS"},
                new Supplier {SupplierId = 8089, Name = "EXCLUSIVE TOURS"},
                new Supplier {SupplierId = 8837, Name = "SCANDITOURS"},
                new Supplier {SupplierId = 9285, Name = "JTB INTERNATIONAL (CANADA)"},
                new Supplier {SupplierId = 9323, Name = "BONAVE"},
                new Supplier {SupplierId = 9396, Name = "SKYLINK TICKET CENTRE"},
                new Supplier {SupplierId = 9766, Name = "KINTETSU INTERNATIONAL"},
                new Supplier {SupplierId = 9785, Name = "MANDITOURS INTL INC."},
                new Supplier {SupplierId = 11156, Name = "ALITOURS INTERNATIONAL INC."},
                new Supplier {SupplierId = 11160, Name = "TOTAL ADVANTAGE TRAVEL"},
                new Supplier {SupplierId = 11163, Name = "D-TOUR MARKETING"},
                new Supplier {SupplierId = 11172, Name = "MERIT TRAVEL GROUP INC."},
                new Supplier {SupplierId = 11174, Name = "GRUPO TACA"},
                new Supplier {SupplierId = 11237, Name = "DKM COACH LINES LTD"},
                new Supplier {SupplierId = 11549, Name = "GO ACTIVE VACATIONS"},
                new Supplier {SupplierId = 12657, Name = "SAAAI TRAVEL INC."},
                new Supplier {SupplierId = 13596, Name = "A & TIC SUPPORT INC."}
            };

        #endregion

        #region IEqualityComparer<Supplier>

        bool IEqualityComparer<Supplier>.Equals(Supplier x, Supplier y)
        {
            return x.SupplierId == y.SupplierId && x.Name == y.Name;
        }

        int IEqualityComparer<Supplier>.GetHashCode(Supplier obj)
        {
            return obj.Name.GetHashCode() * 17 + obj.SupplierId.GetHashCode();
        }

        #endregion

    }
}
