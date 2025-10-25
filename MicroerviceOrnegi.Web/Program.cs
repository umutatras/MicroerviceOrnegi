using MicroerviceOrnegi.Web.DelegateHandlers;
using MicroerviceOrnegi.Web.ExceptionHandlers;
using MicroerviceOrnegi.Web.Extensions;
using MicroerviceOrnegi.Web.Options;
using MicroerviceOrnegi.Web.Pages.Auth.SignIn;
using MicroerviceOrnegi.Web.Pages.Auth.SignUp;
using MicroerviceOrnegi.Web.Services;
using MicroerviceOrnegi.Web.Services.Refit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc(opt => opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddOptionsExt();

builder.Services.AddHttpClient<SignUpService>();
builder.Services.AddHttpClient<SignInService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CatalogService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<AuthenticatedHttpClientHandler>();
builder.Services.AddScoped<ClientAuthenticatedHttpClientHandler>();
builder.Services.AddExceptionHandler<UnauthorizedAccessExceptionHandler>();

builder.Services.AddRefitClient<ICatalogRefitService>().ConfigureHttpClient(configure =>
{
    var microserviceOption = builder.Configuration.GetSection(nameof(MicroserviceOption)).Get<MicroserviceOption>();
    configure.BaseAddress = new Uri(microserviceOption!.Catalog.BaseAddress);
}).AddHttpMessageHandler<AuthenticatedHttpClientHandler>()
    .AddHttpMessageHandler<ClientAuthenticatedHttpClientHandler>();

builder.Services.AddRefitClient<IBasketRefitService>().ConfigureHttpClient(configure =>
{
    var microserviceOption = builder.Configuration.GetSection(nameof(MicroserviceOption)).Get<MicroserviceOption>();
    configure.BaseAddress = new Uri(microserviceOption!.Basket.BaseAddress);
}).AddHttpMessageHandler<AuthenticatedHttpClientHandler>()
    .AddHttpMessageHandler<ClientAuthenticatedHttpClientHandler>();


builder.Services.AddRefitClient<IDiscountRefitService>().ConfigureHttpClient(configure =>
{
    var microserviceOption = builder.Configuration.GetSection(nameof(MicroserviceOption)).Get<MicroserviceOption>();
    configure.BaseAddress = new Uri(microserviceOption!.Discount.BaseAddress);
}).AddHttpMessageHandler<AuthenticatedHttpClientHandler>()
    .AddHttpMessageHandler<ClientAuthenticatedHttpClientHandler>();

builder.Services.AddAuthentication(configureOption =>
{
    configureOption.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    configureOption.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Auth/SignIn";
        options.ExpireTimeSpan = TimeSpan.FromDays(60);
        options.Cookie.Name = "UdemyNewMicroserviceWebCookie";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });
builder.Services.AddAuthorization();
var app = builder.Build();

var culterInfo = new System.Globalization.CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = culterInfo;
CultureInfo.DefaultThreadCurrentUICulture = culterInfo;
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culterInfo),
    SupportedCultures = new List<CultureInfo> { culterInfo },
    SupportedUICultures = new List<CultureInfo> { culterInfo }
});
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
