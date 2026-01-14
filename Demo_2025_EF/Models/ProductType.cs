using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }

        [MaxLength(200)]
        public string? TypeName { get; set; }

        public double? TypeCoefficient { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
