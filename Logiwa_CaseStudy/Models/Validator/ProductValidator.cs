using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Models.Validator // işin algoritması / kuralları burada. must have
{
    public class ProductValidator : AbstractValidator<Product> // Product ile ilgili işlemleri vereceğiz içine
    {
        private readonly ApplicationDBContext _context;

        public ProductValidator(ApplicationDBContext context)
        {
            _context = context;
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty.").NotNull().WithMessage("Title can not be null.").MaximumLength(200); // boşluk ve null

            RuleFor(x => x).Must(x => IsCategoryExist(x)).WithMessage(x => $"{x.CategoryID} numbered ID does not have category."); // kategori olmalı kuralı

            RuleFor(x => x.StockQuantity) //Product quantity check
                .GreaterThanOrEqualTo(x => x.category.MinStockQuantity)
                .When(m => IsCategoryExist(m) == true) // kategori var olduğunda kontrol sağla
                .WithMessage(m => $"Ürün stok sayısı, kategorinin belirlediğinden düşük. Stok sayısı {m.category.MinStockQuantity} adet veya daha fazla olmalı"); // rule set


            bool IsCategoryExist(Product p)
            {
                try
                {
                    var checker = _context.Categories.FirstOrDefault(m => m.ID == p.CategoryID);

                    if (checker != null)
                    {
                        p.category = checker; // kategori var mı ? kategori limiti cout sağlamak için.
                        return true;
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
