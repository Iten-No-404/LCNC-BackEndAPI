using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Interfaces
{
    public interface IPropertyValue<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        T GetProperty(int ID);
        void Insert(T entity);
        void Delete(T entity);
    }
}
