using Logiwa_CaseStudy.Models;
using System.Collections.Generic;

namespace Logiwa_CaseStudy.Services
{
    public interface ICategoryService
    {
        List<Category> ListAllCategories();

        void Create(CreateCategoryDto model);

        void Update(int id, CreateCategoryDto model);

        void Delete(int id);
    }
}
