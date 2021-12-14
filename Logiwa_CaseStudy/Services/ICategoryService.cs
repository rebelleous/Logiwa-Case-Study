using Logiwa_CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public interface ICategoryService
    {
        List<Category> ListAllCategories();

        void Create(CreateCategory model);

        void Update(int id, CreateCategory model);

        void Delete(int id);
    }
}
