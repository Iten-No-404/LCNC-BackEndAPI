using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class PropertyService : IServices<Property>
    {
        private readonly iRepository<Property> _PropertyRepository;
        public PropertyService(iRepository<Property> PropertyRepository)
        {
            _PropertyRepository = PropertyRepository;
        }
        public void Delete(Property entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyRepository.Delete(entity);
                    _PropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Property Get(int Id)
        {
            try
            {
                var obj = _PropertyRepository.Get(Id);
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

        public IEnumerable<Property> GetAll()
        {
            try
            {
                var obj = _PropertyRepository.GetAll();
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

        public void Insert(Property entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyRepository.Insert(entity);
                    _PropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Property entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyRepository.Remove(entity);
                    _PropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Property entity)
        {
            try
            {
                if (entity != null)
                {
                    _PropertyRepository.Update(entity);
                    _PropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
