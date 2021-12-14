﻿using AutoMapper;
using Logiwa_CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa_CaseStudy.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(CreateCategory model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = getCategory(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> ListAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void Update(int id, CreateCategory model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        private Category getCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
    }
}
