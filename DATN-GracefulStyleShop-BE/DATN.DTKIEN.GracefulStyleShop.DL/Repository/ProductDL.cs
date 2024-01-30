﻿using Dapper;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Constants;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Database;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using System.Collections.Specialized;
using System.Data;
using static Dapper.SqlMapper;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Data.Common;
using System.Transactions;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Repository
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        private IDatabaseConnection _databaseConnection;
        public ProductDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public object GetByFilterDetail(object parametersFilter)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByFilterDetail, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                //var ProductDB = result.Read<ProductDB>();
                var productRespone = ProductDB.GroupBy(x => x.ProductId).Select(x => new
                {
                    ProductId = x.Select(x => x.ProductId).FirstOrDefault(),
                    ProductCode = x.Select(x => x.ProductCode).FirstOrDefault(),
                    ProductName = x.Select(x => x.ProductName).FirstOrDefault(),
                    Discount = x.Select(x => x.Discount).FirstOrDefault(),
                    PublicDate = x.Select(x => x.PublicDate).FirstOrDefault(),
                    Sold = x.Select(x => x.Sold).FirstOrDefault(),
                    TypeId = x.Select(x => x.TypeId).FirstOrDefault(),
                    TypeName = x.Select(x => x.TypeName).FirstOrDefault(),
                    BrandId = x.Select(x => x.BrandId).FirstOrDefault(),
                    BrandName = x.Select(x => x.BrandName).FirstOrDefault(),
                    Description = x.Select(x => x.Description).FirstOrDefault(),
                    PriceDel = x.Select(x => x.PriceDel).FirstOrDefault(),
                    Quantity = x.Select(x => x.Quantity).FirstOrDefault(),
                    PriceSale = x.Select(x => x.PriceSale).FirstOrDefault(),
                    IsMassDiscount = x.Select(x => x.IsMassDiscount).FirstOrDefault(),
                    MassDiscount = x.Select(x => x.MassDiscount).FirstOrDefault(),
                    Images = x.GroupBy(x => x.ImageId).Select(x => new Image()
                    {
                        ImageId = x.Select(x => x.ImageId).FirstOrDefault(),
                        ImageLink = x.Select(x => x.ImageLink).FirstOrDefault(),
                        ImageName = x.Select(x => x.ImageName).FirstOrDefault(),
                    }).ToList(),
                    ProductVariants = x.GroupBy(x => new { x.ProductVariantId , x.ColorId } ).Select(x => new ProductVariant()
                    {
                        ProductVariantId = x.Key.ProductVariantId,
                        ColorId = x.Key.ColorId,
                        ColorCode = x.Select(x => x.ColorCode).FirstOrDefault(),
                        Sizes = x.GroupBy(x => x.SizeId).Select(x => new Size()
                        {
                            SizeId = x.Key,
                            SizeCode = x.Select(x => x.SizeCode).FirstOrDefault()
                        }).ToList()
                    }).ToList()
                }).ToList();


                storedProducedureName = "Proc_Product_GetTotalProduct";

                int totalProduct = _databaseConnection.Connection().QueryFirstOrDefault<int>(storedProducedureName, commandType: CommandType.StoredProcedure);


                var data = new
                {
                    Total = totalProduct,
                    Data = productRespone.ToList()
                };

                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public override PagingResult<Product> GetByFilter(object parametersFilter)
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
                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                //var ProductDB = result.Read<ProductDB>();
                var productDictionary = new Dictionary<Guid, Product>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Product, Image, Product>(
                                    storedProducedureName,
                                    (product, image) =>
                                    {
                                        Product productEntry;
                                        if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                                        {
                                            productEntry = product;
                                            productEntry.Images = new List<Image>();
                                            productDictionary.Add(productEntry.ProductId, productEntry);
                                        }
                                        if(image != null)
                                        {
                                            productEntry.Images.Add(image);
                                        }
                                        return productEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parameters,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();

                var data = new PagingResult<Product>
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
                Console.WriteLine(ex);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public override Product GetById(Guid id)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetById, typeof(Product).Name);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                var productDictionary = new Dictionary<Guid, Product>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Product, Image, Product>(
                                    storedProducedureName,
                                    (product, image) =>
                                    {
                                        Product productEntry;
                                        if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                                        {
                                            productEntry = product;
                                            productEntry.Images = new List<Image>();
                                            productDictionary.Add(productEntry.ProductId, productEntry);
                                        }

                                        productEntry.Images.Add(image);
                                        return productEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parametes,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();

                // Đóng kết nối
                _databaseConnection.Close();

                return result[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public object GetByIDDetail(Guid id)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = string.Format(NameProduceConstants.GetByIdDetail, typeof(Product).Name);

                // Thêm parameter
                var parametes = new DynamicParameters();
                parametes.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProducedureName, parametes, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                var productRespone = ProductDB.GroupBy(x => x.ProductId).Select(x => new
                {
                    ProductId = x.Select(x => x.ProductId).FirstOrDefault(),
                    ProductCode = x.Select(x => x.ProductCode).FirstOrDefault(),
                    ProductName = x.Select(x => x.ProductName).FirstOrDefault(),
                    Discount = x.Select(x => x.Discount).FirstOrDefault(),
                    PublicDate = x.Select(x => x.PublicDate).FirstOrDefault(),
                    Sold = x.Select(x => x.Sold).FirstOrDefault(),
                    TypeId = x.Select(x => x.TypeId).FirstOrDefault(),
                    BrandId = x.Select(x => x.BrandId).FirstOrDefault(),
                    BrandName = x.Select(x => x.BrandName).FirstOrDefault(),
                    TypeName = x.Select(x => x.TypeName).FirstOrDefault(),
                    Description = x.Select(x => x.Description).FirstOrDefault(),
                    PriceDel = x.Select(x => x.PriceDel).FirstOrDefault(),
                    Quantity = x.Select(x => x.Quantity).FirstOrDefault(),
                    PriceSale = x.Select(x => x.PriceSale).FirstOrDefault(),
                    Images = x.GroupBy(x => x.ImageId).Select(x => new
                    {
                        ImageId = x.Select(x => x.ImageId).FirstOrDefault(),
                        ImageLink = x.Select(x => x.ImageLink).FirstOrDefault(),
                        ImageName = x.Select(x => x.ImageName).FirstOrDefault(),
                    }).ToList(),
                    Colors = x.GroupBy(x => new {x.ColorId }).Select(x => new 
                    {
                        ColorId = x.Key.ColorId,
                        ColorCode = x.Select(x => x.ColorCode).FirstOrDefault(),
                        ColorName = x.Select(x => x.ColorName).FirstOrDefault(),
                        Sizes = x.GroupBy(x => new { x.SizeId,x.ProductVariantId}).Select(x => new 
                        {
                            ProductVariantId = x.Key.ProductVariantId,
                            SizeId = x.Key.SizeId,
                            Quantity = x.Key.ProductVariantId,
                            SizeCode = x.Select(x => x.SizeCode).FirstOrDefault(),
                            ProductVariantQuantity = x.Select(x => x.ProductVariantQuantity).FirstOrDefault()
                        }).ToList()
                    }).ToList(),
                    Sizes = x.GroupBy(x => x.SizeId).Select(x => new
                    {
                        SizeId = x.Key,
                        SizeCode = x.Select(x => x.SizeCode).FirstOrDefault(),
                        ProductVariantQuantity = x.Select(x => x.ProductVariantQuantity).FirstOrDefault()
                    }).ToList(),
                }).ToList().ElementAt(0);

               
                // Đóng kết nối
                _databaseConnection.Close();

                return productRespone;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public bool UpdateSold(Guid productId, int sold)
        {
            try
            {
                string query = $"Update {tableName} set Sold = {sold} where {tableName}Id = {productId}";

                //Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                //Xử lý update dữ liệu số lượng bán
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
                Console.WriteLine(ex);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public bool MassDiscount(MassDiscountModel massDiscountModel)
        {
            try
            {
                int numberRecoredDeleted;
                string query = "";

                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();
                if (massDiscountModel.Types.Count == 0 && massDiscountModel.Brands.Count == 0)
                {
                    query = "update product set IsMassDiscount = 0 where IsMassDiscount = 1";
                    numberRecoredDeleted = _databaseConnection.Connection().Execute(query, commandType: CommandType.Text,transaction:_databaseConnection.Transaction());
                }
                else
                {
                    query = $"Update product set IsMassDiscount = 1 , MassDiscount = {massDiscountModel.DiscountNumber} where BrandId in (@Id)";
                    numberRecoredDeleted = _databaseConnection.Connection().Execute(query, massDiscountModel.Brands.AsEnumerable().Select(i => new { Id = i.ToString() }).ToList(), transaction:_databaseConnection.Transaction());
                    query = $"Update product set IsMassDiscount = 1 , MassDiscount = {massDiscountModel.DiscountNumber} where TypeId in (@Id)";
                    numberRecoredDeleted = _databaseConnection.Connection().Execute(query, massDiscountModel.Types.AsEnumerable().Select(i => new { Id = i }).ToList(), transaction: _databaseConnection.Transaction());
                }
                _databaseConnection.CommitTransaction();
                _databaseConnection.Close();
                 return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public MassDiscountModel GetMassDiscount()
        {
            try
            {
                var result = new MassDiscountModel();
                // Tên store produce
                string storedProducedureName = "Proc_Proc_GetMassDiscount";
                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý thêm dữ liệu trong stored
                var res = _databaseConnection.QueryMultiple(storedProducedureName, commandType: CommandType.StoredProcedure);

                result = new MassDiscountModel()
                {
                    Brands = res.Read<MassDiscountBrand>().Select(x => x.BrandId).ToList(),
                    Types = res.Read<MassDiscountType>().Select(x => x.TypeId).ToList()
                };

                // Đóng kết nối
                _databaseConnection.Close();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
    }
}
