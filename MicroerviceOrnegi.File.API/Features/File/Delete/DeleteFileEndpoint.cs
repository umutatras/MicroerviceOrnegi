using MediatR;
using MicroerviceOrnegi.Shared.Extensions;

namespace MicroerviceOrnegi.File.API.Features.File.Delete
{

    public static class DeleteFileEndpoint
    {
        public static RouteGroupBuilder DeleteFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{fileName:string}", async (string fileName, IMediator mediator) => (await mediator.Send(new DeleteFileCommand(fileName))).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
