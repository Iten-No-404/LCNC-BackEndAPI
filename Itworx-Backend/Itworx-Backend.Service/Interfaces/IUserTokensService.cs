using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Interfaces
{
    public interface IUserTokensService<T> where T : class
    {
        T Get(long id);
        T Get(string uuid);
        void Insert(T entity);
        void Update(T entity);
    }
}
