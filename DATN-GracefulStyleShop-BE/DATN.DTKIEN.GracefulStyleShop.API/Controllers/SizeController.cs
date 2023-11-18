
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class SizeController : BaseController<Size>
    {
        private IBaseService<Size> _baseService;
        public SizeController(IBaseService<Size> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
