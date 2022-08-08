using Itworx_Backend.Domain;
using Itworx_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Repository.Repository
{
    public interface iRepository < T > where T: baseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        User Get(string email);

        TargetFramework GetFramework(string name);

        AppType GetType(string Type);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
