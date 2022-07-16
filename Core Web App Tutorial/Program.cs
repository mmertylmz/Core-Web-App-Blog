//Libraries that I add.

using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//Authorization config
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//ReturnUrl komutu, Bu sayede hep a�a��daki yazd���m�z path'e d�nece�iz.
builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

//Identity i�lemlerinin ger�ekle�mesi i�in eklemem gereken servis yap�s�
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false; //�ifrede b�y�k karakter girme zorunlulu�u kalkt�. asp-validation-summary'de bu k�s�m g�z�kmeyecek.
}).AddEntityFrameworkStores<Context>();

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

app.UseAuthentication(); //Authentication'u �al��t�rmak i�in yazmam�z gereken komut

//Session Kullanma Komutu.
//app.UseSession();


app.UseRouting();


app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute( //PresentationLayer'�m�n i�inde olu�turdu�um areas klas�r�n� 404'ten kurtarmak i�in bir route belirlemem laz�m. Burada o i�lemi ger�ekle�tirdim.
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.Run();



//https://docs.microsoft.com/tr-tr/aspnet/core/migration/50-to-60-samples?view=aspnetcore-5.0

//app.UseEndpoints(endpoints => //Core 5.0'da yaz�m� bu �ekilde
//{
//    endpoints.MapControllerRoute(
//           name: "areas",
//           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//         );
//});
