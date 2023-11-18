using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Interfaces
{
    public interface IUserTokenDL : IBaseDL<UserToken>
    {
        public UserToken GetUserByToken(string token);
        public bool DeleleToken(string token);

    }
}
