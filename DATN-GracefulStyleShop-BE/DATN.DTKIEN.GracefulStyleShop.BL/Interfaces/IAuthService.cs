﻿using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Interfaces
{
    public interface IAuthService
    {
        public dynamic AuthenticateUser(LoginRequest loginRequest);
    }
}
