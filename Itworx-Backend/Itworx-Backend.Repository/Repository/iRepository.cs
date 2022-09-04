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
        userToken GetToken(string uuid);
        User Get(string email);

        TargetFramework GetFramework(string name);

        AppType GetType(string Type);

        Unit Getname(string Name);

        Widget GetTitle(string title);

        WidgetCodeSnippet GetCodeSnippet(int id);

        PropertyValue GetProperty(int ID);
        IEnumerable<Project> GetbyUserID(int userID);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
