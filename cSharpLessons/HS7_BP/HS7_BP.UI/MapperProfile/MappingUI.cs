using AutoMapper;
using HS7_BP.Application.Models.DTOs.AppUserDTOs;
using HS7_BP.Application.Models.DTOs.CategoryDTOs;
using HS7_BP.UI.Areas.Admin.ViewModels;
using HS7_BP.UI.Models.VM;

namespace HS7_BP.UI.MapperProfile
{
    public class MappingUI : Profile
    {

        public MappingUI()
        {
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();

            CreateMap<LoginDTO, LoginVM>().ReverseMap();

            CreateMap<CategoryCreateDTO, CategoryCreateVM>().ReverseMap();
            CreateMap<CategoryListDTO, CategoryListVM>().ReverseMap();
            CreateMap<CategoryEditVM, CategoryUpdateDTO>().ReverseMap();
        }
    }
}

