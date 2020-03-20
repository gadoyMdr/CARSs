using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARS.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
