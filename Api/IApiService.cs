namespace Api
{
    public interface IApiService
    {
        public Task SendUser();
        public Task SendPost();
        public Task SendComment();
    }
}
