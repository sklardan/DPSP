using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_UI_LG.Helpers
{
    public enum ApiRequesType
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE
    }
    public class Request
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> ToApi(string data, string url, ApiRequesType requestType = ApiRequesType.GET)
        {
            using (var client = new HttpClient())
            {
                if (Helpers.Ident.IsLogged) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Helpers.Ident.Get().access_token);
                var content = new StringContent(string.Empty);
                if(!string.IsNullOrWhiteSpace(data)) content = new StringContent(data, Encoding.UTF8, "application/json");/*x-www-form-urlencoded*/
                Task<HttpResponseMessage> response;
                switch (requestType)
                {
                    case ApiRequesType.POST:
                        response = client.PostAsync(url, content);
                        break;
                    default:
                        response = client.GetAsync(url);
                        break;
                }
                try
                {
                    return await response.Result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    return $"Exception: {ex.Message} API server is probably not responding.";
                }

            }
        }

    }

}