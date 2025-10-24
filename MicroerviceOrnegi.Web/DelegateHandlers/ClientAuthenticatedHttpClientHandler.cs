﻿using Duende.IdentityModel.Client;
using MicroerviceOrnegi.Web.Options;
using MicroerviceOrnegi.Web.Services;

namespace MicroerviceOrnegi.Web.DelegateHandlers
{
    public class ClientAuthenticatedHttpClientHandler(
     IdentityOption identityOption,
     IHttpContextAccessor httpContextAccessor,
     TokenService tokenService) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (httpContextAccessor.HttpContext is null) return await base.SendAsync(request, cancellationToken);

            if (httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
                return await base.SendAsync(request, cancellationToken);


            var tokenResponse = await tokenService.GetClientAccessToken();


            if (tokenResponse.IsError)
                throw new UnauthorizedAccessException($"Client Token request failed: {tokenResponse.Error}");

            request.SetBearerToken(tokenResponse.AccessToken!);


            return await base.SendAsync(request, cancellationToken);
        }
    }
}
