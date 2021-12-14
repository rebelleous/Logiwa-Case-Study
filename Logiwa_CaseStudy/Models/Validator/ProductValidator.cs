using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models.Validator // işin algoritması / kuralları burada. must have
{
    public class ProductValidator : AbstractValidator<CrUpProduct> // Product ile ilgili işlemleri vereceğiz içine
    {
        private readonly ApplicationDBContext _context;

        public ProductValidator(ApplicationDBContext context)
        {
            _context = context;
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty.").NotNull().WithMessage("Title can not be null.").MaximumLength(200); // boşluk ve null

            RuleFor(x => x).Must(x => IsCategoryExist(x.CategoryID)).WithMessage(x => $"{x.CategoryID} numbered ID does not have category."); // kategori olmalı kuralı

            RuleFor(x => x) //Product quantity check
                .Must(x=> FindCategoryMinQuantity(CategoryID:x.CategoryID,quantity:x.StockQuantity))
                .WithMessage(m => $"Product's Stock Quantity is less than Category's Minimum Stock Quantity."); // rule set
            

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
