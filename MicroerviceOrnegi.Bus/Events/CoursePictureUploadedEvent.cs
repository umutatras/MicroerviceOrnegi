﻿namespace MicroerviceOrnegi.Bus.Events
{
    public record CoursePictureUploadedEvent(Guid CourseId, string ImageUrl);
}
