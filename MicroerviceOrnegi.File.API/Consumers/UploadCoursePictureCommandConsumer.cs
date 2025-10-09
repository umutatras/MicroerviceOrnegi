using MassTransit;
using MicroerviceOrnegi.Bus.Commands;
using MicroerviceOrnegi.Bus.Events;
using Microsoft.Extensions.FileProviders;

namespace MicroerviceOrnegi.File.API.Consumers
{
    public class UploadCoursePictureCommandConsumer(IServiceProvider provider) : IConsumer<UploadCoursePictureCommand>
    {
        public async Task Consume(ConsumeContext<UploadCoursePictureCommand> context)
        {
            using var scope = provider.CreateScope();
            var fileProvider = scope.ServiceProvider.GetRequiredService<IFileProvider>();


            var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(context.Message.FileName)}"; // .jpg

            var uploadPath = Path.Combine(fileProvider.GetFileInfo("files").PhysicalPath!, newFileName);


            await System.IO.File.WriteAllBytesAsync(uploadPath, context.Message.Picture);
            var publishEndpoint = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();


            await publishEndpoint.Publish(new CoursePictureUploadedEvent(context.Message.CourseId,
                $"files/{newFileName}"));
        }
    }
}
