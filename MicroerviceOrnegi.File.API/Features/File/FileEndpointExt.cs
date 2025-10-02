using Asp.Versioning.Builder;
using MicroerviceOrnegi.File.API.Features.File.Delete;
using MicroerviceOrnegi.File.API.Features.File.Upload;

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
                .DeleteFileGroupItemEndpoint()
                .RequireAuthorization()
                ;

        }
    }

}
