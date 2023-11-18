﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.Common.Models
{
    public class Cart : Image
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceSale { get; set; }
        public bool IsMassDiscount { get; set; }
        public int MassDiscount { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public List<Image> Images { get; set; }

        public int ProVariantQuantity { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return PriceSale * (decimal)(1 - (IsMassDiscount ? MassDiscount : Discount) * 0.01) * Quantity;
            }
        }
        public decimal TotalDel
        {
            get
            {
                return Quantity * PriceSale;
            }
        }
        public decimal PriceDel
        {
            get
            {
                return PriceSale * (decimal)(1 - (IsMassDiscount ? MassDiscount : Discount) * 0.01);
            }
            set
            {
                value = PriceDel;
            }
        }
    }
}
