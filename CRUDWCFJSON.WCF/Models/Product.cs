﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWCFJSON.WCF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }        
        public DateTime CreationDate { get; set; }
    }
}