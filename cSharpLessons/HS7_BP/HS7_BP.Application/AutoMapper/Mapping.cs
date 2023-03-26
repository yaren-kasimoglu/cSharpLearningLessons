using AutoMapper;
using HS7_BP.Application.Models.DTOs.AppUserDTOs;
using HS7_BP.Application.Models.DTOs.CategoryDTOs;
using HS7_BP.Application.Models.DTOs.PostDTOs;
using HS7_BP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Application.AutoMapper
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            //CreateMap<RegisterDTO,ResiterVM>().ReverseMap()

            //Category
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();

            //Post
            CreateMap<Post, PostCreateDTO>().ReverseMap();
            CreateMap<Post, PostUpdateDTO>().ReverseMap();
            //CreateMap<Post, PostListDTO>().ForMember(x=>x.LikeCount,y=>y.MapFrom(z=>z.Likes.Count)); burada değil de UI tarafında yapacağız.
            CreateMap<Post, PostUpdateDTO>().ReverseMap();



        }
    }
}
