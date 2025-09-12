using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.File.API.Features.File.Upload
{
    public record UploadFileCommand(IFormFile File):IRequestByServiceResult<UploadFileCommandResponse>;
    
}
