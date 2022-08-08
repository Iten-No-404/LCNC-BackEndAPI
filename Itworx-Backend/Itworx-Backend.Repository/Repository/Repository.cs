using Itworx_Backend.Domain;
using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Repository.Repository
{
    public class Repository < T > : iRepository < T > where T: baseEntity
    {
        #region property
        
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
        private DbSet<User> userentities;
        private DbSet<TargetFramework> Frameworkentities;
        private DbSet<AppType> Appentities;

        #endregion

        #region Constructor
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
            userentities = _applicationDbContext.Set<User>();
            Frameworkentities = _applicationDbContext.Set<TargetFramework>();
            Appentities = _applicationDbContext.Set<AppType>();
        }
        #endregion
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }
        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public User Get(string email)
        {
            return userentities.SingleOrDefault(c => c.Email == email);
        }

        

        public TargetFramework GetFramework(string name)
        {
            return Frameworkentities.SingleOrDefault(c => c.FrameworkName == name);
        }

        public AppType GetType(string type)
        {
            return Appentities.SingleOrDefault(c => c.type == type);
        }


        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
