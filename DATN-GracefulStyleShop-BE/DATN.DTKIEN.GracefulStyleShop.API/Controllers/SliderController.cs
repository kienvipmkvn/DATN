using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    public class SliderController : BaseController<Slider>
    {
        private IBaseService<Slider> _baseSerive;
        public SliderController(IBaseService<Slider> baseSerive, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(baseSerive, httpContextAccessor, userTokenService)
        {
            _baseSerive = baseSerive;
        }
      
    }
}
