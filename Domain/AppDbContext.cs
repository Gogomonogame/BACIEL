using College.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace College.Domain
{
    // Контекст БД
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Absence> Absences { get; set; } = null!;
        public DbSet<Timetable> Timetables { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin";
            string adminPassword = "adminpass";
            string roleAdminId = Guid.NewGuid().ToString();
            string userAdminId = Guid.NewGuid().ToString();

            //Додаємо роль адміністратора сайту
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            //Додаємо нового IdentityUser Для адміністратора сайту
            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                NormalizedUserName = adminName.ToUpper(),
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminPassword),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            //Додаємо адміна в роль
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });
        }
    }
}
