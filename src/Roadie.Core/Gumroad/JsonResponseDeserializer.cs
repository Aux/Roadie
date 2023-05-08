using RestEase;
using System.Text.Json;

namespace Roadie.Gumroad
{
    public class JsonResponseDeserializer : ResponseDeserializer
    {
        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default;

            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
