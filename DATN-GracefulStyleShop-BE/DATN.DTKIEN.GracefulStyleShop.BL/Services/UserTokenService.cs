using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class UserTokenService : IUserTokenService
    {
        private IUserTokenDL _userTokenDL;
        public UserTokenService(IUserTokenDL userTokenDL)
        {
            _userTokenDL = userTokenDL;
        }

        public UserToken GetUserByToken(string token)
        {
            return _userTokenDL.GetUserByToken(token);
        }
    }
}
