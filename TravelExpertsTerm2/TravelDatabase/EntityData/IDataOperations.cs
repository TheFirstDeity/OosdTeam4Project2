// Author: Team 4 (See Annotations)
// Project: TravelExpertsTerm2
// Date: 2016-01

using System.Collections.Generic;
using JetBrains.Annotations;

namespace TravelDatabase.EntityProviders
{

    // This is an interface, https://msdn.microsoft.com/en-us/library/ms173156.aspx
    // Two important ones you'll see are IEnumerable<T> & INotifyPropertyChanged.
    [Heidi]
    public interface IDataOperations<TEntity>

        // constraint (where clause) makes it so that the type that TEntity is a class with a default constructor
        // https://msdn.microsoft.com/en-us/library/d5x73970.aspx
        where TEntity : class, new()
    {
        //defines signatures that the DB classes must implement
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntityById(int id);
        bool DeleteEntity(TEntity entity);
        int AddEntity(TEntity entity);
        bool UpdateEntity(TEntity entity);
    }
}