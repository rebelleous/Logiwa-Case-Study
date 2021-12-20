using FluentValidation;
using System;
using System.Linq;

namespace Logiwa_CaseStudy.Models.Validator
{
    /// <summary>
    /// Rule validations for product.
    /// </summary>
    public class ProductValidator : AbstractValidator<CreateUpdateProductDto> 
    {
        private readonly ApplicationDBContext _context;

        public ProductValidator(ApplicationDBContext context)
        {
            _context = context;
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty.").NotNull().WithMessage("Title can not be null.").MaximumLength(200); 

            RuleFor(x => x).Must(x => IsCategoryExist(x.CategoryID)).WithMessage(x => $"{x.CategoryID} numbered ID does not have category.");


            RuleFor(x => x) 
                .Must(x=> FindCategoryMinQuantity(x.CategoryID,x.StockQuantity) =="1")
                .WithMessage(m => FindCategoryMinQuantity(m.CategoryID, m.StockQuantity)); 
            

            bool IsCategoryExist(int CategoryID)
            {
                try
                {
                    var checker = _context.Categories.FirstOrDefault(m => m.ID == CategoryID);

                    if (checker != null)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            string FindCategoryMinQuantity(int CategoryID, int quantity)
            {
                try
                {
                    var category = _context.Categories.FirstOrDefault(m => m.ID == CategoryID);

                    if (category != null)
                    {
                        if (quantity >= category.MinStockQuantity)
                        {
                            return 1.ToString();
                        }
                        return $"Product's Stock Quantity is less than Category's Minimum Stock Quantity. Category want {category.MinStockQuantity}";
                    }
                    return "Category is not exists";
                }
                catch (Exception)
                {
                    return "Category is not exists";
                }
            }

        }
    }
}
