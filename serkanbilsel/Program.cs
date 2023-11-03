



using serkanbilsel.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(); // Burada veritaban� i�lemleri i�in kulland���m�z contexti tan�t�yoruz.
builder.Services.AddControllersWithViews();

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



app.MapControllerRoute(    // AREA EKLED�KTEN SONRA SCAFFOLD�NGREADME.TXT DEN ALDI�IMIZ KODLARI BURAYA YAPI�TIRDIK ��NK� AREA NIN �ALI�MASI ���N BU ROUTE U EKLEMEM�Z GEREK�YOR
              name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"  //  DEFAULT OLAN KISIM "HOME" DI B�Z �SM� DEFAULT VERD���M�Z ���N DEFAULT YAPTIK
          );


app.MapControllerRoute( // uygulaman�n kullanaca�� routing y�nlendirme ayar�
    name: "default", // route ad� 
    pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er adres �ubu�unda

app.Run();
