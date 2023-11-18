using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using DATN.DTKIEN.GracefulStyleShop.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.DL.Interfaces
{
    public interface IFileDL
    {
        public bool Insert(List<Image> images);

        public List<Image> GetFileByObjectId(Guid id);

        public bool DeleteFile(List<Guid> listId);
    }
}