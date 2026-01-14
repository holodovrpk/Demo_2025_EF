using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Demo_2025_EF.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

        public int? MaterialId { get; set; }
        public Material? Material { get; set; }

        [MaxLength(150)]
        public string? ProductName { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public decimal? MinPrice { get; set; }

        public double? Size { get; set; }

        public decimal? Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
