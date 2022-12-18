using AutoMapper;
using CRMProject.DTO.Pages;
using CRMProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.BL.Utility.AutoMapper
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccountDTO, UserAccount>();

            //.ForMember(dest=>dest.UserName, opt=>opt.MapFrom(src=>src.UserName)) isimlerde farklılık varsa veya iki alanı bir alana atayacaksak vs bu işlemlerde yapıyoruz
            

            //Destination Source şeklince çalışıyor hangi kaynaktan nhangi hedefe
            CreateMap<UserAccount, UserAccountDTO>();
        }
    }
}
