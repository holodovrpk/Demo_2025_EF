using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Demo_2025_EF.Models
{
    public class MaterialType
    {
        public int MaterialTypeId { get; set; }

        [MaxLength(150)]
        public string? TypeName { get; set; }
        public double? DefectPercent { get; set; }

        public ICollection<Material> Materials { get; set; }
    }
}
