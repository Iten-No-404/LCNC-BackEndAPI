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
        private DbSet<Unit> Unitentities;
        private DbSet<Widget> Widgetentities;
        private DbSet<Project> Projectentities;
        private DbSet<WidgetCodeSnippet> WidgetCodeSnippetentities;
        private DbSet<PropertyValue> PropertyValueentities;

        #endregion

        #region Constructor
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
            userentities = _applicationDbContext.Set<User>();
            Frameworkentities = _applicationDbContext.Set<TargetFramework>();
            Appentities = _applicationDbContext.Set<AppType>();
            Unitentities = _applicationDbContext.Set<Unit>();
            Widgetentities = _applicationDbContext.Set<Widget>();
            Projectentities = _applicationDbContext.Set<Project>();
            WidgetCodeSnippetentities = _applicationDbContext.Set<WidgetCodeSnippet>();
            PropertyValueentities = _applicationDbContext.Set<PropertyValue>();
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

        public Unit Getname(string name)
        {
            return Unitentities.SingleOrDefault(c => c.UnitName == name);
        }
        public Widget GetTitle(string title)
        {
            return Widgetentities.SingleOrDefault(c => c.text == title);
        }


        public IEnumerable<Project> GetbyUserID(int userID)
        {
            return Projectentities.Where(c => c.user_Id == userID).Select(c => c).AsEnumerable();
        }

        public WidgetCodeSnippet GetCodeSnippet(int id)
        {
            return WidgetCodeSnippetentities.SingleOrDefault(c => c.widgetId == id);
        }


        public PropertyValue GetProperty(int ID)
        {
            return PropertyValueentities.SingleOrDefault(c => c.propertyID == ID);
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
