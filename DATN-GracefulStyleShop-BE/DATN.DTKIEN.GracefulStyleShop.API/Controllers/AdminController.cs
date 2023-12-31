﻿using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Services;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class AdminController : BaseController<Admin>
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService, IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService) : base(adminService, httpContextAccessor, userTokenService)
        {
            _adminService = adminService;
        }
    }
}
