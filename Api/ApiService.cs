using System.Net;

using RestSharp;

namespace Api
{
    public class ApiService: IApiService
    {
        private string webHookUrl = "https://webhook.site/7557f49e-8c23-455a-bd71-f72d8b770a3a/";

        public async Task SendUser()
        {
            var url = webHookUrl + "user";
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id = 5, name = "Ben" });

            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Access problem to {url}, Error: {resp.ErrorMessage}");
            }
        }

        public async Task SendPost()
        {
            var url = webHookUrl + "post";
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id = 1, text = "Test post" });

            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Access problem to {url}, Error: {resp.ErrorMessage}");
            }
        }

        public async Task SendComment()
        {
            var url = webHookUrl + "comment";
            var client = new RestClient(url);
            var request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id = 3, text = "Test comment" });

            var resp = await client.ExecuteAsync(request);

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Access problem to {url}, Error: {resp.ErrorMessage}");
            }
        }
    }
}