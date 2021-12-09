//ORM Tool.//
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) //SQL bağlantı ayarı.
        {

        }

        public DbSet<Category> Categories { get; set; } //Veritabanında ne ile eşleşecek onu belirtiyor.
        public DbSet<Product> Products { get; set; }
    }
}
