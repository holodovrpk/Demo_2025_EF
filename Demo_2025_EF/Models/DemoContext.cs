using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2025_EF.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerType> PartnersType { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get;   set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к LocalDB (MS SQL Server Express).
            // Сервер: (localdb)\mssqllocaldb
            // Имя базы: BolnichkaBD
            // Trusted_Connection=True — используется Windows-авторизация.
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Demo2025;Trusted_Connection=True;");
        }

        // Конструктор контекста.
        public DemoContext()
        {
            // EnsureCreated():
            //   - Проверяет, существует ли база.
            //   - Если нет — создаёт БЕЗ миграций.
            // Важно: если будешь использовать миграции, эту строку нужно убрать,
            // потому что EnsureCreated и Migrations несовместимы.
            Database.EnsureCreated();
        }
    }
}
