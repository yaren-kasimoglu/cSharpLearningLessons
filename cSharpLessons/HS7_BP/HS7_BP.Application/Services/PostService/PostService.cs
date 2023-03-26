using AutoMapper;
using HS7_BP.Application.Models.DTOs.PostDTOs;
using HS7_BP.Domain.Entities;
using HS7_BP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Application.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<PostListDTO>> AllPosts()
        {
            return _mapper.Map<List<PostListDTO>>(await _postRepository.GetAll());
        }

        public async Task Create(PostCreateDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);

            await _postRepository.Add(post);
        }

        public async Task Edit(PostUpdateDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            await _postRepository.Update(post);
        }

        public async Task<PostUpdateDTO> GetById(Guid id)
        {
            Post post = await _postRepository.GetBy(x => x.Id == id && x.Status == Domain.Enums.Status.Active);
            return _mapper.Map<PostUpdateDTO>(post);
        }

        public async Task<List<PostListDTO>> GetDefaults(Expression<Func<Post, bool>> expression)
        {
            var postList = await _postRepository.GetDefault(expression);
            return _mapper.Map<List<PostListDTO>>(postList);
        }

        public async Task Remove(Guid id)
        {
            Post post = await _postRepository.GetBy(x => x.Id == id && x.Status == Domain.Enums.Status.Active);

            await _postRepository.Delete(post);

        }
    }
}
