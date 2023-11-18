using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Interfaces
{
    public interface ICartDL : IBaseDL<Cart>
    {
        public int CartNumber(Guid CustomerId);

        public bool UpdateQuantity(Guid id, int quantity);
    }
}
