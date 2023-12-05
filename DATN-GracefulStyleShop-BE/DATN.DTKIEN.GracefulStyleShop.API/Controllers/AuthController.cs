using DATN.DTKIEN.GracefulStyleShop.API.Hepers;
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Services;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Enums;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AuthController : MControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserTokenDL _userTokenDL;
        public AuthController(IHttpContextAccessor httpContextAccessor, IAuthService authService, IUserTokenDL userTokenDL)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
            _userTokenDL = userTokenDL;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] LoginRequest loginRequest)
        {

            try
            {
                // Xử lý
                var result = _authService.AuthenticateUser(loginRequest);

                if (result.ErrorCode is null) return StatusCode(StatusCodes.Status200OK, result);
                else if (result.ErrorCode == EnumErrorCode.NOT_CONTENT) return StatusCode(StatusCodes.Status204NoContent, result);
                else if (result.ErrorCode == EnumErrorCode.BADREQUEST) return StatusCode(StatusCodes.Status400BadRequest, result);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            catch (MExceptionResponse ex)
            {
                Console.WriteLine(ex);
                // Bắn lỗi exeption
                return ExceptionErrorResponse(ex, HttpContext.TraceIdentifier);
            }
        }

        [HttpDelete]
        [Route("signout/{token}")]
        public IActionResult SignOut([FromRoute] string token)
        {

            bool response = _userTokenDL.DeleleToken(token);

            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
