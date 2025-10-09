using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroerviceOrnegi.Bus.Commands
{
    public record UploadCoursePictureCommand(Guid CourseId, Byte[] Picture);
}
