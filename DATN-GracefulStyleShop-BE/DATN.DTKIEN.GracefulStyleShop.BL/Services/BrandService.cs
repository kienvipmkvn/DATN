using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        private readonly IBrandService _brandService;
        public BrandService(IBaseDL<Brand> baseDL) : base(baseDL)
        {
        }

        ///// <summary>
        ///// Xóa nhiều bản ghi
        ///// </summary>
        ///// <param name="listId">ListID</param>
        ///// <returns>Số bản ghi thay đổi</returns>
        //public override bool DeleteRecords(List<Guid> listId)
        //{
        //    return _baseDL.DeleteUpdateRecords(listId);
        //}
    }
}
