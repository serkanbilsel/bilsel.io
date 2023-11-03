using Microsoft.EntityFrameworkCore;
using serkanbilsel.Entities;
using serkanbilsel.Models;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace serkanbilsel.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
       
        public DbSet<News> News { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Likes> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // OnCinfiguring metodu EntitityFrameWorkCore ile gelir ve veritabanı bağlantı ayarlarını yapmamızı sağlar.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=sbio; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);

            //CANLI BİR DATABASE BAĞLANTISI YAPMAK İÇİN AŞAĞIDAKİ ADIMLARI UYGULA

            // optionsBuilder.UseSqlServer(@"Server=CanlıServerAdı; Database=CanlıDatabaseAdı;
            // Username=CanlıVeritabanıKullanıcıAdı; Password=CanlıVeritabanıŞifre);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENTAPI VERTABANINDAKİ KOLONLARIN AYARLANMASINI SAĞLAYAN YAPIDIR
            //FLuentAPI ile veritabanı tablolarımız oluşurken veri tiplerini db kurallarını burada tanımlayabiliriz.
            modelBuilder.Entity<AppUser>().Property(a => a.Name).IsRequired().HasMaxLength(50);
            //FluentAPİ ile AppUser Classının Name Propertysi için oluşacak veritabanı kolonu ayarlarını bu şekilde belirledik
            modelBuilder.Entity<AppUser>().Property(a => a.Surname).HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.UserName).HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Password).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            modelBuilder.Entity<AppUser>().Property(a => a.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Phone).HasMaxLength(20);

            //FLUENTAPI HasData ile db oluştuktan sonra başlangıç kayıtları ekleme
            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = 1,
                Email = "info@sb.io",
                Password = "12qk12qk",
                UserName = "Serkan",
                IsActive = true,
                IsAdmin = true,
                Name = "Admin",
                UserGuid = Guid.NewGuid(),// Kullanıcıya benzersiz bir id no oluşturuyoruz.
            });





            // DATABASE İÇİN ÖZELLİKLERİNİ CLASS AÇARAK VERDİĞİMİZ BU PROPORTYLERİ KISA YOLDAN EKLEMEK İÇİN AŞAĞIDAKİ YÖNTEMİ DENE

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // uygulamadıki tüm configurations classlarını burada çalıştır



            base.OnModelCreating(modelBuilder);



        }


    }
}
