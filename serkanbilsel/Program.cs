using serkanbilsel.Data;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();


 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(    // AREA EKLED�KTEN SONRA SCAFFOLD�NGREADME.TXT DEN ALDI�IMIZ KODLARI BURAYA YAPI�TIRDIK ��NK� AREA NIN �ALI�MASI ���N BU ROUTE U EKLEMEM�Z GEREK�YOR
              name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"  //  DEFAULT OLAN KISIM "HOME" DI B�Z �SM� DEFAULT VERD���M�Z ���N DEFAULT YAPTIK
          );


app.MapControllerRoute( // uygulaman�n kullanaca�� routing y�nlendirme ayar�
    name: "default", // route ad� 
    pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er adres �ubu�unda





app.Run();
