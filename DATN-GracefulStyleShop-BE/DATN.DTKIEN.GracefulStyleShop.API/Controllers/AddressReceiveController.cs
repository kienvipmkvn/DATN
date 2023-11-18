﻿using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    public class AddressReceiveController : BaseController<AddressReceive>
    {
        private IAddressReceiveService _addressReceiveService;
        public AddressReceiveController(IAddressReceiveService addressReceiveService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(addressReceiveService, httpContextAccessor, userTokenService)
        {
            _addressReceiveService = addressReceiveService;
        }

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpGet]
        [Route("xxx")]
        [AllowAnonymous]
        public virtual IActionResult SetDefaultxxx()
        {
            return Ok("TETST");
        }

        /// <summary>
        /// Lấy thông tin có bộ lọc
        /// </summary>
        /// <param name="paramFilter">Bộ lọc</param>
        /// <returns>Thông tin đối tượng</returns>
        [HttpPut]
        [Route("Set-Default")]
        public virtual IActionResult SetDefault([FromBody] AddressReceiveSetDefauModel addressReceiveSetDefauModel)
        {
            try
            {
                // Xử lý
                var result = _addressReceiveService.SetDefault(addressReceiveSetDefauModel);

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

        public override IActionResult GetByFilter([FromBody] PagingModel paramFilter)
        {
            paramFilter.parentId = userToken.UserID;
            return base.GetByFilter(paramFilter);
        }
        public override IActionResult Insert([FromBody] AddressReceive entity)
        {
            entity.CustomerId = userToken.UserID;
            return base.Insert(entity);
        }
    }
}
