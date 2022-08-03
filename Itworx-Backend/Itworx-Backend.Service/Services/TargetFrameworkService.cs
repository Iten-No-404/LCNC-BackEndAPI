using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class TargetFrameworkService : IServices<TargetFramework>
    {
        private readonly iRepository<TargetFramework> _TargetFrameworkRepository;
        public TargetFrameworkService(iRepository<TargetFramework> TargetFrameworkRepository)
        {
            _TargetFrameworkRepository = TargetFrameworkRepository;
        }
        public void Delete(TargetFramework entity)
        {
            try
            {
                if (entity != null)
                {
                    _TargetFrameworkRepository.Delete(entity);
                    _TargetFrameworkRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TargetFramework Get(int Id)
        {
            try
            {
                var obj = _TargetFrameworkRepository.Get(Id);
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

        public IEnumerable<TargetFramework> GetAll()
        {
            try
            {
                var obj = _TargetFrameworkRepository.GetAll();
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

        public void Insert(TargetFramework entity)
        {
            try
            {
                if (entity != null)
                {
                    _TargetFrameworkRepository.Insert(entity);
                    _TargetFrameworkRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(TargetFramework entity)
        {
            try
            {
                if (entity != null)
                {
                    _TargetFrameworkRepository.Remove(entity);
                    _TargetFrameworkRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(TargetFramework entity)
        {
            try
            {
                if (entity != null)
                {
                    _TargetFrameworkRepository.Update(entity);
                    _TargetFrameworkRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
