using DATN.DTKIEN.GracefulStyleShop.API.Helpers;
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditCardController : Authentication
    {
        private ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(httpContextAccessor, userTokenService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CreditCardInfo creditCardInfo)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = new ServiceResult();

                result.Data = await _creditCardService.Checkout(creditCardInfo);

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
