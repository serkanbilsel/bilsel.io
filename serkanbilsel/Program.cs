



using serkanbilsel.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(); // Burada veritabaný iþlemleri için kullandýðýmýz contexti tanýtýyoruz.
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



app.MapControllerRoute(    // AREA EKLEDÝKTEN SONRA SCAFFOLDÝNGREADME.TXT DEN ALDIÐIMIZ KODLARI BURAYA YAPIÞTIRDIK ÇÜNKÜ AREA NIN ÇALIÞMASI ÝÇÝN BU ROUTE U EKLEMEMÝZ GEREKÝYOR
              name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"  //  DEFAULT OLAN KISIM "HOME" DI BÝZ ÝSMÝ DEFAULT VERDÝÐÝMÝZ ÝÇÝN DEFAULT YAPTIK
          );


app.MapControllerRoute( // uygulamanýn kullanacaðý routing yönlendirme ayarý
    name: "default", // route adý 
    pattern: "{controller=Home}/{action=Index}/{id?}"); // eðer adres çubuðunda

app.Run();
