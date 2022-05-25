using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Data.Dto;
using Data.Models;
using Data;

namespace Services
{
    public class DataService : IDbService
    {
        protected IRepository _repo;
        protected readonly IMapper _mapper;

        public DataService(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task AddNewUsers(IEnumerable<UserDto> users)
        {
            var existedUserIds = _repo.Context.Users.Select(x => x.Id).ToList();
            var usersToAdd = users.Where(x => !existedUserIds.Contains(x.Id)).ToList();
            if (usersToAdd.Count > 0)
            {
                usersToAdd.ForEach(async x =>
                {
                    var entity = _mapper.Map<User>(x);
                    await _repo.AddAsync(entity);
                });
                await _repo.Context.SaveChangesAsync();
            }
        }

        public async Task AddNewPosts(IEnumerable<PostDto> posts)
        {
            var existedPostIds = _repo.Context.Posts.Select(x => x.Id).ToList();
            var postsToAdd = posts.Where(x => !existedPostIds.Contains(x.Id)).ToList();
            if (postsToAdd.Count > 0)
            {
                postsToAdd.ForEach(async x =>
                {
                    var entity = _mapper.Map<Post>(x);
                    await _repo.AddAsync(entity);
                });
                await _repo.Context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _repo.Context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByToken(string token)
        {
            var user = await _repo.Context.Users.FirstOrDefaultAsync(x => x.Token == token);
            return _mapper.Map<UserDto>(user);
        }

    }
}
