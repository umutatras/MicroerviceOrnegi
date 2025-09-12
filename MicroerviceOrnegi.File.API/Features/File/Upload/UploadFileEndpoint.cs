using MediatR;
using MicroerviceOrnegi.Shared.Extensions;

namespace MicroerviceOrnegi.File.API.Features.File.Upload
{
    public static class UploadFileEndpoint
    {
        public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (UploadFileCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }

}
