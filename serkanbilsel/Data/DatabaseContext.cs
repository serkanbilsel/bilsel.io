using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace serkanbilsel.Data
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // Bu metot veritabanı ayarlarını yapılandırabildiğimiz metot
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database =serkanbilsel; trusted_connection=true");
            // UseSqlServer ile bu projede veritabanı olarak sql server kullanacağımızı belirttik.

            // "" içerisindeki alana connection string yani veritabanı bilgilerini yazıyoruz. 

            // @ koyarak özel karakterleri görmezden geliyoruz.
            base.OnConfiguring(optionsBuilder);
        }

    }
}





