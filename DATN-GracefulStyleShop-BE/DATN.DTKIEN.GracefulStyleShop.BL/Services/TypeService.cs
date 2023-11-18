using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class TypeService : BaseService<DATN.DTKIEN.GracefulStyleShop.Common.Models.Type>, ITypeService
    {
        public TypeService(IBaseDL<DATN.DTKIEN.GracefulStyleShop.Common.Models.Type> baseDL) : base(baseDL)
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
