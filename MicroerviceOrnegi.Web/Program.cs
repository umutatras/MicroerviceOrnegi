using MicroerviceOrnegi.Web.Extensions;
using MicroerviceOrnegi.Web.Pages.Auth.SignIn;
using MicroerviceOrnegi.Web.Pages.Auth.SignUp;
using MicroerviceOrnegi.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(opt=>opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes=true);
builder.Services.AddOptionsExt();

builder.Services.AddHttpClient<SignUpService>();
builder.Services.AddHttpClient<SignInService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
