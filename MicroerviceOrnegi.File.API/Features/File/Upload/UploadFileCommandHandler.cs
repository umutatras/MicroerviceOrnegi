using MediatR;
using MicroerviceOrnegi.Shared;
using Microsoft.Extensions.FileProviders;

namespace MicroerviceOrnegi.File.API.Features.File.Upload
{
    public class UploadFileCommandHandler(IFileProvider provider) : IRequestHandler<UploadFileCommand, ServiceResult<UploadFileCommandResponse>>
    {
        public Task<ServiceResult<UploadFileCommandResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
