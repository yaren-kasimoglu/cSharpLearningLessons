using HS7_BP.Application.Models.DTOs.PostDTOs;
using HS7_BP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Application.Services.PostService
{
    public interface IPostService
    {
        Task Create(PostCreateDTO postDTO);
        Task Edit(PostUpdateDTO postDTO);
        Task Remove(Guid id);

        Task<List<PostListDTO>> GetDefaults(Expression<Func<Post, bool>> expression);
        Task<List<PostListDTO>> AllPosts();
        Task<PostUpdateDTO> GetById(Guid id);


    }
}
