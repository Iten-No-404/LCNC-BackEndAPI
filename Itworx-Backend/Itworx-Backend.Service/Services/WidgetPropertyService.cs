using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class WidgetPropertyService : IServices<WidgetProperty>
    {
        private readonly iRepository<WidgetProperty> _WidgetPropertyRepository;
        public WidgetPropertyService(iRepository<WidgetProperty> WidgetPropertyRepository)
        {
            _WidgetPropertyRepository = WidgetPropertyRepository;
        }
        public void Delete(WidgetProperty entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetPropertyRepository.Delete(entity);
                    _WidgetPropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WidgetProperty Get(int Id)
        {
            try
            {
                var obj = _WidgetPropertyRepository.Get(Id);
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

        public IEnumerable<WidgetProperty> GetAll()
        {
            try
            {
                var obj = _WidgetPropertyRepository.GetAll();
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

        public void Insert(WidgetProperty entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetPropertyRepository.Insert(entity);
                    _WidgetPropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(WidgetProperty entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetPropertyRepository.Remove(entity);
                    _WidgetPropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(WidgetProperty entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetPropertyRepository.Update(entity);
                    _WidgetPropertyRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
