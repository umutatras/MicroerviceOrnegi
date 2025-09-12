using MediatR;
using MicroerviceOrnegi.Shared;
using Microsoft.Extensions.FileProviders;

namespace MicroerviceOrnegi.File.API.Features.File.Delete
{
    public class DeleteFileCommandHandler(IFileProvider provider) : IRequestHandler<DeleteFileCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var fileInfo = provider.GetFileInfo(Path.Combine("files",request.FileName));


            if (!fileInfo.Exists)
                return ServiceResult.Error("File Not Found", "The file you are trying to delete does not exist.", System.Net.HttpStatusCode.NotFound);

            System.IO.File.Delete(fileInfo.PhysicalPath!);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
