using Logiwa_CaseStudy.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Helpers
{
    public class SeedingData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDBContext>();
            // update database if there is a new migration
            context.Database.Migrate();

            // add category if there is none
            if (context.Set<Category>().Count() == 0)
            {
                context.Set<Category>().AddRange(
                    new List<Category>()
                    {
                        new Category(){Name="Elektronik",MinStockQuantity=5},
                        new Category(){Name="Moda",MinStockQuantity=10},
                        new Category(){Name="Spor",MinStockQuantity=15},
                        new Category(){Name="Otomotiv",MinStockQuantity=20},

                    }
                    );
            }
            // add product if there is none
            if (context.Set<Product>().Count() == 0)
            {
                context.Set<Product>().AddRange(
                new List<Product>()
                {
                         new Product() {Description="Karşınızda şimdiye kadarki en hızlı ve en güçlü Xbox olan Xbox Series X.",StockQuantity=40,CategoryID=1,Title="Microsoft Xbox Series X Oyun Konsolu Siyah 1 TB"},
                         new Product() {Description="Ürün, genç kullanıcıların günlük kullanımı için tasarlanan ikonik modeller arasında yer alıyor.",StockQuantity=100,CategoryID=2,Title="Nike Air Force 1 Beyaz Spor Ayakkabı"},
                         new Product() {Description="Optimum performans ve orijinal gibi dokunma hissi için yüksek kaliteli kompozit malzeme. Nike N.Fi.04.222.09 All-Field 3.0 Official Amerikan Futbol Topu",StockQuantity=150,CategoryID=3,Title="Nike Official Amerikan Futbolu Topu"},
                         new Product() {Description=" Süper fiber laminat (Fiberglass) dış kabuk, ECE22-05 ve SNELLM2010 sertifikalarına ve entegre havalandırmaya sahip.",StockQuantity=75,CategoryID=4,Title="Arai Chaser-X Shaped Red Kapalı Motosiklet Kaskı"}
                }
                );
            }

            context.SaveChanges();

        }
    }
}
