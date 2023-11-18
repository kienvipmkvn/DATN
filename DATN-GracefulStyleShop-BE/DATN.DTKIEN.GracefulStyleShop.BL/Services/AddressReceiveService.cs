using DATN.DTKIEN.GracefulStyleShop.BL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models.DTO;
using DATN.DTKIEN.GracefulStyleShop.DL.Interfaces;
using DATN.DTKIEN.GracefulStyleShop.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.BL.Services
{
    public class AddressReceiveService : BaseService<AddressReceive>,IAddressReceiveService
    {
        private readonly IAddressReceiveDL _addressReceiveDL;
        public AddressReceiveService(IAddressReceiveDL addressReceiveDL) : base(addressReceiveDL)
        {
            _addressReceiveDL = addressReceiveDL;
        }
        public bool SetDefault(AddressReceiveSetDefauModel addressReceiveSetDefauModel)
        {
            return _addressReceiveDL.SetDefault(addressReceiveSetDefauModel);
        }
    }
}
