using MediatR;
using MicroerviceOrnegi.File.API.Features.File.Upload;
using MicroerviceOrnegi.Shared.Filter;
using MicroerviceOrnegi.Shared.Extensions;
using Asp.Versioning.Builder;

namespace MicroerviceOrnegi.File.API.Features.File
{
  public static class FileEndpointExt
    {
        public static void FileGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files")
                .WithTags("Files")
                .WithApiVersionSet(apiVersionSet)
                .UploadFileGroupItemEndpoint()
                ;
                
        }
    }

}
