using MediatR;
using MicroerviceOrnegi.Shared.Extensions;

namespace MicroerviceOrnegi.File.API.Features.File.Upload
{
    public static class UploadFileEndpoint
    {
        public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (IFormFile file, IMediator mediator) => (await mediator.Send(new UploadFileCommand(file))).ToGenericResult()).MapToApiVersion(1, 0).DisableAntiforgery();

            return group;
        }
    }

}
