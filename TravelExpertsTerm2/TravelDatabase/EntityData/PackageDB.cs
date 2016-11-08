// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDatabase.EntityProviders;

namespace TravelDatabase.EntityData
{
    public class PackageDB : IDataOperations<Package>
    {
        public bool AddEntity(Package entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(Package entity)
        {
            throw new NotImplementedException();
        }

        public List<Package> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Package GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(Package entity)
        {
            throw new NotImplementedException();
        }

        int IDataOperations<Package>.AddEntity(Package entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Package> IDataOperations<Package>.GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
