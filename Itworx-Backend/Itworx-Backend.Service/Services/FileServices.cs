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
    public class FileServices : IServices<ImageFile>
    {
        private readonly iRepository<ImageFile> _ImageFileRepository;
        public FileServices(iRepository<ImageFile> ImageFileRepository)
        {
            _ImageFileRepository = ImageFileRepository;
        }
        public void Delete(ImageFile entity)
        {
            try
            {
                if (entity != null)
                {
                    _ImageFileRepository.Delete(entity);
                    _ImageFileRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ImageFile Get(int Id)
        {
            try
            {
                var obj = _ImageFileRepository.Get(Id);
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

        public IEnumerable<ImageFile> GetAll()
        {
            try
            {
                var obj = _ImageFileRepository.GetAll();
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

        public void Insert(ImageFile entity)
        {
            try
            {
                if (entity != null)
                {
                    _ImageFileRepository.Insert(entity);
                    _ImageFileRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(ImageFile entity)
        {
            try
            {
                if (entity != null)
                {
                    _ImageFileRepository.Remove(entity);
                    _ImageFileRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ImageFile entity)
        {
            try
            {
                if (entity != null)
                {
                    _ImageFileRepository.Update(entity);
                    _ImageFileRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
