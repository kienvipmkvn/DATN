using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Services;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class ColorController : BaseController<Color>
    {
        private IBaseService<Color> _baseService;
        public ColorController(IBaseService<Color> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
