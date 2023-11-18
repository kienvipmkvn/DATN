﻿using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Interfaces
{
    public interface IProductService: IBaseService<Product>
    {
        public bool UpdateSold(Guid productId, int sold);
        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parameters">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public object GetByFilterDetail(dynamic parameters);

        public object GetByIDDetail([FromRoute] Guid id);

        public bool MassDiscount(MassDiscountModel massDiscountModel);
        public MassDiscountModel GetMassDiscount();
    }
}
