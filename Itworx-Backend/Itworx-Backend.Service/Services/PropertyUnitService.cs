using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class PropertyUnitService : IServices<PropertyUnit>
    {
        private readonly iRepository<PropertyUnit> _PropertyUnitRepository;
        public PropertyUnitService(iRepository<PropertyUnit> PropertyUnitRepository)
        {
            _PropertyUnitRepository = PropertyUnitRepository;
        }
        public void Delete(PropertyUnit entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyUnitRepository.Delete(entity);
                    _PropertyUnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PropertyUnit Get(int Id)
        {
            try
            {
                var obj = _PropertyUnitRepository.Get(Id);
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

        public IEnumerable<PropertyUnit> GetAll()
        {
            try
            {
                var obj = _PropertyUnitRepository.GetAll();
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

        public void Insert(PropertyUnit entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyUnitRepository.Insert(entity);
                    _PropertyUnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(PropertyUnit entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyUnitRepository.Remove(entity);
                    _PropertyUnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(PropertyUnit entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyUnitRepository.Update(entity);
                    _PropertyUnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
