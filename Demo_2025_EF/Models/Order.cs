using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int? PartnerId { get; set; }
        public Partner? Partner { get; set; }

        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
