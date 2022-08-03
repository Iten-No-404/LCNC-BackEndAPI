using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class AppTypeService : IServices<AppType>
    {
        private readonly iRepository<AppType> _AppTypeRepository;
        public AppTypeService(iRepository<AppType> AppTypeRepository)
        {
            _AppTypeRepository = AppTypeRepository;
        }
        public void Delete(AppType entity)
        {
            try
            {
                if (entity != null)
                {
                    _AppTypeRepository.Delete(entity);
                    _AppTypeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AppType Get(int Id)
        {
            try
            {
                var obj = _AppTypeRepository.Get(Id);
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

        public IEnumerable<AppType> GetAll()
        {
            try
            {
                var obj = _AppTypeRepository.GetAll();
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

        public void Insert(AppType entity)
        {
            try
            {
                if (entity != null)
                {
                    _AppTypeRepository.Insert(entity);
                    _AppTypeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(AppType entity)
        {
            try
            {
                if (entity != null)
                {
                    _AppTypeRepository.Remove(entity);
                    _AppTypeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(AppType entity)
        {
            try
            {
                if (entity != null)
                {
                    _AppTypeRepository.Update(entity);
                    _AppTypeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
