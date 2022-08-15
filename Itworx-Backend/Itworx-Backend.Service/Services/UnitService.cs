using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itworx_Backend.Service.Interfaces;

namespace Itworx_Backend.Service.Services
{
    public class UnitService : Iunit<Unit>
    {
        private readonly iRepository<Unit> _UnitRepository;
        public UnitService(iRepository<Unit> UnitRepository)
        {
            _UnitRepository = UnitRepository;
        }
        public void Delete(Unit entity)
        {
            try
            {
                if (entity != null)
                {
                    _UnitRepository.Delete(entity);
                    _UnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Unit Get(int Id)
        {
            try
            {
                var obj = _UnitRepository.Get(Id);
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

        public Unit Get(string name)
        {
            try
            {
                var obj = _UnitRepository.Getname(name);
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

        public IEnumerable<Unit> GetAll()
        {
            try
            {
                var obj = _UnitRepository.GetAll();
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

        public void Insert(Unit entity)
        {
            try
            {
                if (entity != null)
                {
                    _UnitRepository.Insert(entity);
                    _UnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Unit entity)
        {
            try
            {
                if (entity != null)
                {
                    _UnitRepository.Remove(entity);
                    _UnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Unit entity)
        {
            try
            {
                if (entity != null)
                {
                    _UnitRepository.Update(entity);
                    _UnitRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
