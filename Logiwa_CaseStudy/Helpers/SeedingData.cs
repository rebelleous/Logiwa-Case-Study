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
                        new Category(){Name="Kırtasiye",MinStockQuantity=10},
                        new Category(){Name="Ofis",MinStockQuantity=15},
                        new Category(){Name="Oyuncak",MinStockQuantity=20},

                    }
                    );
            }
            // add product if there is none
            if (context.Set<Product>().Count() == 0)
            {
                context.Set<Product>().AddRange(
                new List<Product>()
                {
                         new Product() {Description="Hızını anlatmaya kelimeler yetişemez.Bir akıllı telefondaki en hızlı çip olan A14 Bionic.",StockQuantity=200,CategoryID=1,Title="Iphone 12 64 GB"},
                         new Product() {Description="Yazı yazarken ve çizim yaparken yorulmamanız için altıgen olarak tasarlanan Rotring 500 versatil kalem serisi orijinal ve birinci kalite plastik gövdeye ve maksimum tutuşu sağlayacak metal tutma alanına sahiptir.",StockQuantity=150,CategoryID=2,Title="Rotring 500 Siyah Versatil Kalem"},
                         new Product() {Description="Thunder Pro Çalışma Sandalyesi, en çok satan ofis sandalyesi kategorisinde ilk sırada gelmektedir.",StockQuantity=50,CategoryID=3,Title="Seduna Thunder Pro Siyah"},
                         new Product() {Description="Kutu Oyunu Tabu XL Özellikleri Oyun partilerinin vazgeçilmezi Tabu XL sizlerle! Tabu XL'da tam 4 farklı anlatım şekli var.",StockQuantity=100,CategoryID=4,Title="Kutu Oyunu Tabu XL"}
                }
                );
            }

            context.SaveChanges();

        }
    }
}
