﻿using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itworx_Backend.Service.Interfaces;

namespace Itworx_Backend.Service.Services
{
    public class TargetFrameworkService : ItargetFramework<TargetFramework>
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

        public TargetFramework Get(string name)
        {
            try
            {
                var obj = _TargetFrameworkRepository.GetFramework(name);
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
    }
}
