using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System.Net.Http.Headers;

namespace WebApp.Integration.Weather.Handlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly ITokenAcquisition _tokenAcquisition;

        public AuthHeaderHandler(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // AME 
            //string Origin = "AME";
            //string scope = "api://281817ad-7a2e-471c-9215-f5fe29b2186c/user_impersonation";
            //var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });

            // EMA 
            string Origin = "EMA";
            string scope = "api://0844130b-51a4-4ebe-ba31-148e4ea1fa92/user_impersonation";
            var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            request.Headers.Add("OriginGeo", Origin);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
