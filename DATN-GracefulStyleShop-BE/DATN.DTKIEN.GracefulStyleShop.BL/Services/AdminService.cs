using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService(IBaseDL<Admin> baseDL) : base(baseDL)
        {
        }

        public override Admin processPropertyCustom(Admin admin, bool isInsert)
        {
            if (isInsert)
            {
                admin.Password= DATN.DTKIEN.GracefulStyleShop.Commons.Commons.MD5Hash("12345678@Abc");
            }

            return admin;
        }
    }
}
