using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Interfaces
{
    public interface IAddressReceiveDL : IBaseDL<AddressReceive>
    {
        public bool SetDefault(AddressReceiveSetDefauModel addressReceiveSetDefauModel);
    }
}
