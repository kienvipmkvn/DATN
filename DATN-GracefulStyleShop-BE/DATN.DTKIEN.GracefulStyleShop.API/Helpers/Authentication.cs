using DATN.DTKIEN.GracefulStyleShop.API.Common;
using DATN.DTKIEN.GracefulStyleShop.API.Hepers;
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.BL.Services;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Helpers
{
    public class Authentication : MControllerBase
    {
        public UserToken userToken = null;
        public bool IsOke = false;
        private readonly IUserTokenService _userTokenService;

        public Authentication(IHttpContextAccessor httpContextAccessor,IUserTokenService userTokenService)
        {
            _userTokenService = userTokenService;

            // List api không cần token

            var request = httpContextAccessor.HttpContext.Request;
            
            if (!request.Path.Equals("/api/v1/customer/"))
            {
                string token = CacheUserToken.GetTokenFromRequest(request);
                userToken = _userTokenService.GetUserByToken(token);
                return;
            }
            IsOke = true;
        }
    }
}
