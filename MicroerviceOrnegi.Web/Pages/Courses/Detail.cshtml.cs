using MicroerviceOrnegi.Web.PageModels;
using MicroerviceOrnegi.Web.Services;
using MicroerviceOrnegi.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroerviceOrnegi.Web.Pages.Courses;

[AllowAnonymous]
public class DetailModel(CatalogService catalogService) : BasePageModel
{
    public CourseViewModel? Course { get; set; }

    public async Task<IActionResult> OnGet(Guid id)
    {
        var courseAsResult = await catalogService.GetCourse(id);

        if (courseAsResult.IsFail) return ErrorPage(courseAsResult);

        Course = courseAsResult.Data!;
        return Page();
    }
}