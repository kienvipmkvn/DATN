using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    public class TypeController : BaseController<DATN.DTKIEN.GracefulStyleShop.Common.Models.Type>
    {
        private IBaseService<DATN.DTKIEN.GracefulStyleShop.Common.Models.Type> _baseService;
        public TypeController(IBaseService<DATN.DTKIEN.GracefulStyleShop.Common.Models.Type> baseService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseService, httpContextAccessor, userTokenService)
        {
            _baseService = baseService;
        }
    }
}
