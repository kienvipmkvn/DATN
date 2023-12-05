﻿using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Enums;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DATN.DTKIEN.GracefulStyleShop.API.Controllers
{
    [AuthenPermission]
    public class CustomerController : BaseController<Customer>
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, IHttpContextAccessor httpContextAccessor, IUserTokenService userTokenService) : base(customerService, httpContextAccessor, userTokenService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Thêm 
        /// </summary>
        /// <param name="entity">Thông tin muốn thêm</param>
        /// <returns>Id mới</returns>
        [HttpPost]
        public override IActionResult Insert([FromBody] Customer customer)
        {
            try
            {
                // Gọi hàm xử lý
                ServiceResult result = _customerService.Insert(customer);

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

    }
}
