using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Interfaces
{
    public interface IuserServices<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);

        T Get(string email);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
    }
}
