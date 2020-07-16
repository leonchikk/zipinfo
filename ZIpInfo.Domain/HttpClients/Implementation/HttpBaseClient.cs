using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ZipInfo.Core.HttpClients;

namespace ZipInfo.Domain.HttpClients.Implementation
{
    public class HttpBaseClient : IHttpBaseClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpBaseClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TResult> GetAsync<TResult>(string clientName, string requestUri, Dictionary<string, string> headers = null)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                var httpClient = _httpClientFactory.CreateClient(clientName);

                var httpResponseMessage = await httpClient.SendAsync(requestMessage);

                var resultContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResult>(resultContent);
            }
        }
    }
}
