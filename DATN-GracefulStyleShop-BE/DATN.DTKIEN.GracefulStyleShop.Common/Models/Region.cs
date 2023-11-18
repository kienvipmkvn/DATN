﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.DTKIEN.GracefulStyleShop.Common.Models
{
    public class Region
    {
        public int RegionID { get; set; }
        public int ParentID { get; set; }
        public int RegionCode { get; set; }
        public string RegionName { get; set; }
        public string RegionNameNotMark { get; set; }
        public int RegionLevel { get; set; }
    }
}
