using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        public ServiceResult Insert(Order order, Guid customerId);
        public bool UpdateStatus(Guid orderId, int status, string CancelReason);
    }
}
