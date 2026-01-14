using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Demo_2025_EF.Models
{
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }

        public int? PartnerTypeId { get; set; }
        public PartnerType? PartnerType { get; set; }

        [MaxLength(100)]
        public string? PartnerName { get; set; }

        [MaxLength(100)]
        public string? DirectorName { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(25)]
        public string? PhoneNumber { get; set; }

        [MaxLength(150)]
        public string? Address { get; set; }

        [MaxLength(15)]
        public string? Inn { get; set; }

        public int? Rating { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
