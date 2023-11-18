using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Enums;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class ProductVariantController : BaseController<ProductVariant>
    {
        public ProductVariantController(IBaseService<ProductVariant> baseService,IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
        }
    }
}
