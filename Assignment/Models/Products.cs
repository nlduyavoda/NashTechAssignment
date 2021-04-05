using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class Products
    {
        [Key]
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> ProductDate { get; set; }
        public string Available { get; set; }
        public string Descriptions { get; set; }
        public Nullable<int> Quantity { get; set; }

    }
}
