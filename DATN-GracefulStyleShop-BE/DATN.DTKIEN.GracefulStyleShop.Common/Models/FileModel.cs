﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.Common.Models
{
    public class FileModel
    {
        public Guid ObjectId { get; set; } = new();
        public List<IFormFile> Files { get; set; }  = new List<IFormFile> { };
        public List<Guid> Images { get; set; } = new List<Guid> { };

    }
}
