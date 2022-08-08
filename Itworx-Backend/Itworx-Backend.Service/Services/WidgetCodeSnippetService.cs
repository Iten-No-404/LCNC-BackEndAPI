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
    public class WidgetCodeSnippetService : IServices<WidgetCodeSnippet>
    {
        private readonly iRepository<WidgetCodeSnippet> _WidgetCodeSnippetRepository;
        public WidgetCodeSnippetService(iRepository<WidgetCodeSnippet> WidgetCodeSnippetRepository)
        {
            _WidgetCodeSnippetRepository = WidgetCodeSnippetRepository;
        }
        public void Delete(WidgetCodeSnippet entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetCodeSnippetRepository.Delete(entity);
                    _WidgetCodeSnippetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WidgetCodeSnippet Get(int Id)
        {
            try
            {
                var obj = _WidgetCodeSnippetRepository.Get(Id);
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

        public IEnumerable<WidgetCodeSnippet> GetAll()
        {
            try
            {
                var obj = _WidgetCodeSnippetRepository.GetAll();
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

        public void Insert(WidgetCodeSnippet entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetCodeSnippetRepository.Insert(entity);
                    _WidgetCodeSnippetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(WidgetCodeSnippet entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetCodeSnippetRepository.Remove(entity);
                    _WidgetCodeSnippetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(WidgetCodeSnippet entity)
        {
            try
            {
                if (entity != null)
                {
                    _WidgetCodeSnippetRepository.Update(entity);
                    _WidgetCodeSnippetRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
