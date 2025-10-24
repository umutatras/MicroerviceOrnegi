using MicroerviceOrnegi.Web.Services;
using MicroerviceOrnegi.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroerviceOrnegi.Web.Pages.Instructor
{
    public class CoursesModel(CatalogService catalogService) : PageModel
    {
        public List<CourseViewModel> CourseViewModels { get; set; } = null!;

        public async Task OnGetAsync()
        {
            var result = await catalogService.GetCoursesByUserId();

            if (result.IsFail)
            {
                //TODO : redirect error page
            }

            CourseViewModels = result.Data!;
        }


        public async Task<IActionResult> OnGetDeleteAsync(Guid id)
        {
            var result = await catalogService.DeleteAsync(id);
            if (result.IsFail)
            {
                //TODO : redirect error page
            }

            return RedirectToPage();
        }
    }
}
