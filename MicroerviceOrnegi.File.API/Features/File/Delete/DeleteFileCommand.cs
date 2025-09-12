using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.File.API.Features.File.Delete
{
    public record DeleteFileCommand(string FileName) : IRequestByServiceResult;
  
}
