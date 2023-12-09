using Infrastructure.Objects;
using System.Dynamic;
using System.Net.Http.Json;

namespace Infrastructure.Utils
{
    public class RequestProcessor
    {
        private string BaseUrl { get; }
        public RequestProcessor(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
        public async Task<string> ClientRequestAsync(BaseRequest request)
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(BaseUrl) };

                object entity = SetUpEntity(request);

                HttpResponseMessage postResponse = await client.PostAsJsonAsync($"/api/{request.Method}", entity);
                
                var responseString = await postResponse.Content.ReadAsStringAsync();

                return responseString;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private object SetUpEntity(BaseRequest request)
        {
            var properies = request.GetType().GetProperties().ToList();

            var genericEntity = new ExpandoObject() as IDictionary<string, object>;

            foreach (var propertyItem in properies)
            {
                if (propertyItem.Name != "Method")
                    genericEntity[propertyItem.Name] = propertyItem.GetValue(request)!;
            }

            return genericEntity;
        }
    }
}
