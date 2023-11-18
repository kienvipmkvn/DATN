﻿using DATN.DTKIEN.GracefulStyleShop.API.Common;
using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Commons;
using DATN.DTKIEN.GracefulStyleShop.Common.Enums;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.Common.Resources;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerDL _customerDL;
        private IUserTokenDL _UserTokenDL;
        public CustomerService(ICustomerDL customerDL, IUserTokenDL userTokenDL) : base(customerDL)
        {
            _customerDL = customerDL;
            _UserTokenDL = userTokenDL;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="enity">Đối tượng</param>
        /// <returns>Danh sách nhân viên</returns>
        public override ServiceResult Insert(Customer customer)
        {
            dynamic result;
            var isValid = this.IsValidate(customer);

            // Kiểm tra validate
            if (isValid)
            {
                customer = AddProperties(customer, true, null, out Guid id);

                bool response = _customerDL.Insert(customer);
                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                UserToken userToken = CacheUserToken.CreateToken(customer);

                response = _UserTokenDL.Insert(userToken);

                if (!response)
                    result = new ServiceResult(EnumErrorCode.SERVER_ERROR, ResourceVI.ErrorServer, ResourceVI.ErrorServer);

                customer.Password = "";

                result = new ServiceResult(new
                {
                    Token = userToken.Token,
                    Customer = customer
                });
            }
            else
            {
                // trả về lỗi validate
                result = new ServiceResult(EnumErrorCode.BADREQUEST, ResourceVI.ErrorValidate, ResourceVI.ErrorValidate, listErrorValidate);
            }

            return result;
        }

        public override void ValidateCustom(Customer entity, bool isInsert = true)
        {
            if (isInsert)
            {
                var customer = _customerDL.getByEmail(entity.Email);
                if (customer != null)
                {
                    listErrorValidate.Add("Email", "Email đã tồn tại");
                }
            }
        }

        public override Customer processPropertyCustom(Customer customer, bool isInsert)
        {
            if(isInsert)
            {
                // mã hóa mật khẩu
                customer.Password = DATN.DTKIEN.GracefulStyleShop.Commons.Commons.MD5Hash(customer.Password);
            }
            return customer;
        }
    }
}
