using System.Collections.Generic;

namespace Leave_Management.Contracts
{
    public interface IRepositoryBase<T> where T : class

    {
        ICollection<T> FindAll();
        T FindById(int id);
        bool IsExists(int id);
        //check if it found
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
