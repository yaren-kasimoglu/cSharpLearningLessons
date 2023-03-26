using HS7_BP.Application.Models.DTOs.CategoryDTOs;
using HS7_BP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Application.Services.CategoryRepository
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDTO categoryDTO);
        Task Edit(CategoryUpdateDTO categoryDTO);
        Task Remove(int id);

        Task<List<CategoryListDTO>> GetDefaults(Expression<Func<Category, bool>> expression);
        Task<List<CategoryListDTO>> AllCategories();
        Task<CategoryUpdateDTO> GetById(int id);
        Task<bool> IsCategoryExsist(string categoryName);




    }
}
