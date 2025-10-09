using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroerviceOrnegi.Bus.Events
{
    public record CoursePictureUploadedEvent(Guid CourseId,string ImageUrl);
}
