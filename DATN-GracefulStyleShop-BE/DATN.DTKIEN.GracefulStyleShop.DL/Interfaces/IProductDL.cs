﻿using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Interfaces
{
    public interface IProductDL : IBaseDL<Product>
    {
        public bool UpdateSold(Guid productId, int sold);
        public object GetByFilterDetail(dynamic parametersFilter);
        public object GetByIDDetail(Guid id);
         public bool MassDiscount(MassDiscountModel massDiscountModel);
         public MassDiscountModel GetMassDiscount();
    }
}
