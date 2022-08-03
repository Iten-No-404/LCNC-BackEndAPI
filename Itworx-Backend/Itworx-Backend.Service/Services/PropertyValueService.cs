using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class PropertyValueService : IServices<PropertyValue>
    {
        private readonly iRepository<PropertyValue> _PropertyValueRepository;
        public PropertyValueService(iRepository<PropertyValue> PropertyValueRepository)
        {
            _PropertyValueRepository = PropertyValueRepository;
        }
        public void Delete(PropertyValue entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyValueRepository.Delete(entity);
                    _PropertyValueRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PropertyValue Get(int Id)
        {
            try
            {
                var obj = _PropertyValueRepository.Get(Id);
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

        public IEnumerable<PropertyValue> GetAll()
        {
            try
            {
                var obj = _PropertyValueRepository.GetAll();
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

        public void Insert(PropertyValue entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyValueRepository.Insert(entity);
                    _PropertyValueRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(PropertyValue entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyValueRepository.Remove(entity);
                    _PropertyValueRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(PropertyValue entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyValueRepository.Update(entity);
                    _PropertyValueRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
