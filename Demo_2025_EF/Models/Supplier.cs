using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [MaxLength(100)]
        public string? SupplierName { get; set; }

        [MaxLength(15)]
        public string? Inn { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
