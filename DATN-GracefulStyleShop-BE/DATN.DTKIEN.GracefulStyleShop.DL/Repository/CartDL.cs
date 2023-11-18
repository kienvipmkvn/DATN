﻿using Dapper;
using DATN.DTKIEN.GracefulStyleShop.Common.Constants;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Repository
{
    public class CartDL : BaseDL<Cart>,ICartDL
    {
        public CartDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public int CartNumber(Guid CustomerId)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format("Proc_Cart_CartNumber", tableName);

                var parameters = new DynamicParameters();
                parameters.Add("p_CustomerId" , CustomerId);

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                int cartNumber = _databaseConnection.QueryFirstOrDefault<int>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                
                // Đóng kết nối
                _databaseConnection.Close();

                return cartNumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public bool UpdateQuantity(Guid id, int quantity)
        {
            try
            {
                string query = $"Update {tableName} set Quantity = {quantity} where {tableName}Id = '{id}'";

                //Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                //Xử lý update dữ liệu số lượng
                int numberUpdate = _databaseConnection.Execute(query, commandType: CommandType.Text);
                if (numberUpdate == 0)
                {
                    return false;
                }
                _databaseConnection.CommitTransaction();
                _databaseConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public override PagingResult<Cart> GetByFilter(object parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByFilter, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();
                //var ProductDB = result.Read<ProductDB>();
                var productDictionary = new Dictionary<Guid, Cart>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Cart, Image, Cart>(
                                    storedProducedureName,
                                    (cart, image) =>
                                    {
                                        Cart cartEntry;
                                        if (!productDictionary.TryGetValue(cart.CartId, out cartEntry))
                                        {
                                            cartEntry = cart;
                                            cartEntry.Images = new List<Image>();
                                            productDictionary.Add(cartEntry.CartId, cartEntry);
                                        }

                                        cartEntry.Images.Add(image);
                                        return cartEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parameters,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();
                var data = new PagingResult<Cart>
                {
                    Total = result.Count(),
                    Data = result.ToList()
                };
                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
