using System.Collections.Generic;

namespace Todo.Domain.Interfaces
{
    public interface IRepository<TEntity> 
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Remove(int id);

        TEntity SelectById(int id);

        IList<TEntity> SelectAll();
    }
}
