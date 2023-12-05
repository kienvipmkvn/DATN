using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Services;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class CartController : BaseController<Cart>
    {
        private ICartService _cartService;
        public CartController(ICartService cartService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(cartService, httpContextAccessor, userTokenService)
        {
            _cartService = cartService;
        }
        public override IActionResult GetByFilter([FromBody] PagingModel paramFilter)
        {
            try
            {
                paramFilter.parentId = userToken.UserID;
                // Xử lý
                var result = _cartService.GetByFilter(paramFilter);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
        [HttpGet]
        [Route("cart-number")]
        public IActionResult CartNumber()
        {
            try
            {
                // Xử lý
                var result = _cartService.CartNumber(userToken.UserID);

                // Trả về thông tin của employee muốn lấy
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpPut]
        [Route("Update-Quantity/{id}")]
        public IActionResult UpdateQuantity([FromRoute] Guid id, [FromBody] int quantity)
        {
            try
            {
                bool result = _cartService.UpdateQuantity(id, quantity);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }
    }
}
