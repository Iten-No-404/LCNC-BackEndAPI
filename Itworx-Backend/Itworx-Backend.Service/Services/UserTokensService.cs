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
    public class UserTokensService : IUserTokensService<userToken>
    {
        private readonly iRepository<userToken> _userTokenRepository;
        public UserTokensService(iRepository<userToken> userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }

        public userToken Get(string uuid)
        {
            try
            {
                var obj = _userTokenRepository.GetToken(uuid);

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

        public void Insert(userToken entity)
        {
            try
            {
                if (entity != null)
                {
                    _userTokenRepository.Insert(entity);
                    _userTokenRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
