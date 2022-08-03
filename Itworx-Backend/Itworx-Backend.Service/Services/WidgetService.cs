using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class WidgetService : IServices<Widget>
    {
        private readonly iRepository<Widget> _WidgetRepository;
        public WidgetService(iRepository<Widget> WidgetRepository)
        {
            _WidgetRepository = WidgetRepository;
        }
        public void Delete(Widget entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetRepository.Delete(entity);
                    _WidgetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Widget Get(int Id)
        {
            try
            {
                var obj = _WidgetRepository.Get(Id);
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

        public IEnumerable<Widget> GetAll()
        {
            try
            {
                var obj = _WidgetRepository.GetAll();
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

        public void Insert(Widget entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetRepository.Insert(entity);
                    _WidgetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Widget entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetRepository.Remove(entity);
                    _WidgetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Widget entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetRepository.Update(entity);
                    _WidgetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
