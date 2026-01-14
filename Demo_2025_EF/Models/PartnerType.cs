using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class PartnerType
    {
        public int PartnerTypeId { get; set; }

        [MaxLength(150)]
        public string? TypeName { get; set; }

        public ICollection<Partner> Partners { get; set; } = new List<Partner>();
    }
}
