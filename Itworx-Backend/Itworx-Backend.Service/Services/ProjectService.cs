using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using Itworx_Backend.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class ProjectService : Iproject<Project>
    {
        private readonly iRepository<Project> _ProjectRepository;
        public ProjectService(iRepository<Project> ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }
        public void Delete(Project entity)
        {
            try
            {
                if (entity != null)
                {
                    _ProjectRepository.Delete(entity);
                    _ProjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Project Get(int Id)
        {
            try
            {
                var obj = _ProjectRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Project> GetAll()
        {
            try
            {
                var obj = _ProjectRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Project> GetbyUserID(int UserID)
        {
            try
            {
                var obj = _ProjectRepository.GetbyUserID(UserID);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Project entity)
        {
            try
            {
                if (entity != null)
                {
                    _ProjectRepository.Insert(entity);
                    _ProjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Project entity)
        {
            try
            {
                if (entity != null)
                {
                    _ProjectRepository.Remove(entity);
                    _ProjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Project entity)
        {
            try
            {
                if (entity != null)
                {
                    _ProjectRepository.Update(entity);
                    _ProjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
