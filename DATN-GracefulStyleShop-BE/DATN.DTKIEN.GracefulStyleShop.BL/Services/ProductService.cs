﻿using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductDL _productDL;
        public ProductService(IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
        }

        public object GetByFilterDetail(object parameters)
        {
            return _productDL.GetByFilterDetail(parameters);
        }

        public object GetByIDDetail(Guid id)
        {
            return _productDL.GetByIDDetail(id);
        }

        public bool MassDiscount(MassDiscountModel massDiscountModel)
        {
            return _productDL.MassDiscount(massDiscountModel);
        }

        public bool UpdateSold(Guid productId, int sold)
        {
            return _productDL.UpdateSold(productId, sold);
        }

        public MassDiscountModel GetMassDiscount()
        {
            return _productDL.GetMassDiscount();
        }
        public override void ValidateCustom(Product entity, bool isInsert = true)
        {
            Guid? productId = _productDL.GetByCode(entity.ProductCode);
        }
    }
}
