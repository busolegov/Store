using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Models.Entities;

namespace Store.DataService
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "557efe88-e537-41f6-b724-89719aa4bb5e",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "0f68adf8-8b36-4c07-8b41-3774401e7eb3",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "o.busenkov@hotmail.com",
                NormalizedEmail = "O.BUSENKOV@HOTMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "557efe88-e537-41f6-b724-89719aa4bb5e",
                UserId = "0f68adf8-8b36-4c07-8b41-3774401e7eb3"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Title = "Видеокарта GIGABYTE GeForce RTX 3050 EAGLE",
                Subtitle = "GV - N3050EAGLE - 8GD",
                Text = "GIGABYTE GeForce RTX 3050 EAGLE обеспечивают оптимальную производительность " +
                       "в топовых играх благодаря возможностям Ampere — архитектуры NVIDIA RTX второго" +
                       " поколения. Оптимальная производительность и качество графики благодаря" +
                       " улучшенным ядрам RT и тензорным ядрам, потоковым мультипроцессорам и" +
                       " высокоскоростной памяти G6. Серия GIGABYTE EAGLE оснащена двумя большими" +
                       " 100 мм вентиляторами для эффективного охлаждения и вентиляционными" +
                       " отверстиями с достаточной площадью на задней панели для оптимального воздушного потока.",
                Price = 40000
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Title = "Видеокарта MSI GeForce RTX 3070 GAMING TRIO PLUS (LHR)",
                Subtitle = "RTX 3070 GAMING TRIO PLUS LHR",
                Text = "Самое свежее воплощение культовой серии Gaming от MSI – это все то же сочетание" +
                       " высокой скорости, эффективного охлаждения и безупречной эстетики, которое давно" +
                       " полюбилось увлеченным геймерам. Такая видеокарта позволит запускать тяжелые игры," +
                       " оставаясь холодной и тихой – именно так, как вам хочется. Настало время показать" +
                       " себя в лучшем свете! Синхронизируйте подсветку видеокарты с иллюминацией остальных" +
                       " компонентов компьютерной системы, чтобы создать подлинно геймерскую атмосферу. " +
                       "Отключить ее так же легко, как выключить свет в комнате.",
                Price = 80000
            });
        }
    }
}
