using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Service.Services
{
    public class UserService : IuserServices<User>
    {
        private readonly iRepository<User> _userRepository;
        public UserService(iRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void Delete(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Delete(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Get(int Id)
        {
            try
            {
                var obj = _userRepository.Get(Id);
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

        public User Get(string email)
        {
            try
            {
                var obj = _userRepository.Get(email);

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
        public IEnumerable<User> GetAll()
        {
            try
            {
                var obj = _userRepository.GetAll();
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

        public void Insert(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Insert(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Remove(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User entity)
        {
            try
            {
                if (entity != null)
                {
                    _userRepository.Update(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
