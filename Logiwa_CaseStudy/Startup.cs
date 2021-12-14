using FluentValidation;
using FluentValidation.AspNetCore;
using Logiwa_CaseStudy.Helpers;
using Logiwa_CaseStudy.Models;
using Logiwa_CaseStudy.Models.Validator;
using Logiwa_CaseStudy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

   
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<ProductValidator>()); // fluent validation inj.
            services.AddTransient<IValidator<CrUpProduct>, ProductValidator>();
            services.AddAutoMapper(typeof(Mapping));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Logiwa_CaseStudy", Version = "v1" });
            });
            services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection"))); //veritabaný tanýmlama
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            
        }

  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Logiwa_CaseStudy v1"));

            SeedingData.Seed(app); // Seed the data
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
