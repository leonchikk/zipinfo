using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZipInfo.Core.HttpClients
{
    public interface IHttpBaseClient
    {
        Task<TResult> GetAsync<TResult>(string clientName, string requestUri, Dictionary<string, string> headers = default);
    }
}
