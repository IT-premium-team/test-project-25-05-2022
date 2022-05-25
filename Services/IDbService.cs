using Data.Dto;

namespace Services
{
    public interface IDbService
    {
        public Task AddNewUsers(IEnumerable<UserDto> users);
        public Task AddNewPosts(IEnumerable<PostDto> posts);
        public Task<IEnumerable<UserDto>> GetUsers();
        public Task<UserDto> GetUserByToken(string token);
    }
}
