using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Interfaces
{
    public interface ICartService : IBaseService<Cart>
    {
        public int CartNumber(Guid CustomerId);

        public bool UpdateQuantity(Guid id, int quantity);
    }
}
