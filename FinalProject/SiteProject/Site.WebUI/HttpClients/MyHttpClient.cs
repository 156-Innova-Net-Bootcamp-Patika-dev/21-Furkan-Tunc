using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Site.WebUI.HttpClients
{
    public class MyHttpClient
    {
        public static async Task<string> MyHttpGet(string method, string action)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(method), $"http://localhost:15432/api/{action}"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "");

                    var response = await httpClient.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return  await response.Content.ReadAsStringAsync();
                    }
                    return null;
                  }
            }
        }

        public static async Task<string> MyHttpCommand(string method, string content, string action)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(method), $"http://localhost:15432/api/{action}"))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");
                    request.Headers.TryAddWithoutValidation("Authorization", "");

                    request.Content = new StringContent(content);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);

                    return await response.Content.ReadAsStringAsync();

                }

            }
        }
    }


}
