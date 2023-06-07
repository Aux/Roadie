using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;

namespace Roadie.Functions
{
    public class DiscordIngestFunction : IHttpFunction
    {
        public Task HandleAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
