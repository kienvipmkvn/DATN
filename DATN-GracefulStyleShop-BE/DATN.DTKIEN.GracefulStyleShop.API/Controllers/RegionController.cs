using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.Common;
using Microsoft.AspNetCore.Mvc;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.API.Hepers;
using DATN.DTKIEN.GracefulStyleShop.API.Helpers;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AuthenPermission]
    public class RegionController : Authentication
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _regionService = regionService;
        }
        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPost]
        public virtual IActionResult GetByFilter(RegionRequest regionRequest)
        {
            try
            {
                // Xử lý
                var result = _regionService.getByParentId(regionRequest.parentId);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
    }
}
