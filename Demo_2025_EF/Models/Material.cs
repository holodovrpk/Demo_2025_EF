using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        public int? MaterialTypeId { get; set; }
        public MaterialType? MaterialType { get; set; }

        [MaxLength(150)]
        public string? MaterialName { get; set; }

        public double? MinQuantity { get; set; }

        public double? Quantity { get; set; }

        public decimal? MaterialPrice { get; set; }

        

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
