//Libraries that I add.
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//https://docs.microsoft.com/tr-tr/aspnet/core/migration/50-to-60-samples?view=aspnetcore-5.0
//Authorization config
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//ReturnUrl komutu, Bu sayede hep aþaðýdaki yazdýðýmýz path'e döneceðiz.
builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });
    


//Insert your builder codes before this code below.
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication(); //Authentication'u çalýþtýrmak için yazmamýz gereken komut

//Session Kullanma Komutu.
//app.UseSession();
app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
