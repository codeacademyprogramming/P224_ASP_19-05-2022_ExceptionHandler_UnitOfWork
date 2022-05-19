using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
