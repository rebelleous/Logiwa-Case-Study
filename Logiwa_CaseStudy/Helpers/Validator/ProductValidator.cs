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
                .Must(x=> FindCategoryMinQuantity(CategoryID:x.CategoryID,quantity:x.StockQuantity))
                .WithMessage(m => $"Product's Stock Quantity is less than Category's Minimum Stock Quantity."); 
            

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

            bool FindCategoryMinQuantity(int CategoryID, int quantity)
            {
                try
                {
                    var category = _context.Categories.FirstOrDefault(m => m.ID == CategoryID);

                    if (category != null)
                    {
                        if (quantity >= category.MinStockQuantity)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
    }
}
