using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [MaxLength(150)]
        public string? FullName { get; set; }

        [MaxLength(10)]
        public string? Login { get; set; }

        [MaxLength(10)]
        public string? Password { get; set; }

        public int? Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
