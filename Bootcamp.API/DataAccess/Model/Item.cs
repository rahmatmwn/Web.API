﻿using Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Item : BaseModel
    {
        public virtual Supplier Suppliers { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
