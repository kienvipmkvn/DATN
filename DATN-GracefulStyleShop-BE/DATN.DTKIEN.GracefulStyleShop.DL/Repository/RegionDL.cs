﻿using Dapper;
using DATN.DTKIEN.GracefulStyleShop.Common.Constants;
using DATN.DTKIEN.GracefulStyleShop.Common;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Database;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Repository
{
    public class RegionDL : IRegionDL
    {
        #region Field
        protected IDatabaseConnection _databaseConnection;
        #endregion

        #region Contructor
        /// <summary>
        /// Khởi tạo kết nối DB
        /// </summary>
        public RegionDL(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        #endregion
        public List<Region> getByParentId(int id)
        {
            try
            {
                // Tên store produce
                string storedProducedureName = "Proc_Region_GetByParentID";

                var parameters = new DynamicParameters();
                parameters.Add("p_ParentID", id);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.QueryMultiple(storedProducedureName, parameters, commandType: CommandType.StoredProcedure);

                var data = result.Read<Region>().ToList();

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
    }
}
