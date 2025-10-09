﻿namespace MicroerviceOrnegi.Catalog.API.Features.Courses.Create
{
    public record CreateCourseCommand(string Name, string Description, decimal Price, IFormFile? Picture, Guid CategoryId) : IRequestByServiceResult<Guid>;

}
