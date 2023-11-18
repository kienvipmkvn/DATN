using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Interfaces
{
    public interface IOrderDL : IBaseDL<Order>
    {
        public bool Insert(Order order,List<OrderDetail> orderDetails,Guid customerId);
        public bool UpdateStatus(Guid orderId, int status,string CancelReason);
    }
}
