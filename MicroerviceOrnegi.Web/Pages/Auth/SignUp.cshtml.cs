using MicroerviceOrnegi.Web.Pages.Auth.SignUp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroerviceOrnegi.Web.Pages.Auth
{
    public class SignUpModel : PageModel
    {
        [BindProperty]public SignUpViewModel SignUpViewModel { get; set; }=SignUpViewModel.Empty;
        public void OnGet()
        {
        }
    }
}
