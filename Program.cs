using College.Domain;
using College.Domain.Repositories.Abstract;
using College.Domain.Repositories.EntityFramework;
using College.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace College
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            

            //Підключаємо в конфіг appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //Перетворюємо секцію Project в об'єктну форму
            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //Підключення контексту БД
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.Database.ConnectionString)
            .ConfigureWarnings(warning => warning.Ignore(RelationalEventId.PendingModelChangesWarning)));

            //
            builder.Services.AddTransient<IGroupRepository, EFGroupRepository>();
            builder.Services.AddTransient<IGradeRepository, EFGradeRepository>();
            builder.Services.AddTransient<IStudentRepository, EFStudentRepository>();
            builder.Services.AddTransient<IAbsenceRepository, EFAbsenceRepository>();
            builder.Services.AddTransient<ISubjectRepository, EFSubjectRepository>();
            builder.Services.AddTransient<ITimetableRepository, EFTimetableRepository>();
            builder.Services.AddTransient<DataManager>();

            //Налаштовуємо Identity систему
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //Налаштовуємо Auth cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myOrganizationAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });



            //Підключаємо функціонал контролерів
            builder.Services.AddControllersWithViews();

            //Підключення логів
            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            //Збираємо конфігурацію
            WebApplication app = builder.Build();

            //!!!!! Порядок слідування middleware важливий, вони будуть виконуватись відповідно до нього

            //Відразу використовуємо логірування
            app.UseSerilogRequestLogging();

            //Далі включаємо обробку виключень
            if(app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //Підключаємо використання статичних файлів wwwroot/
            app.UseStaticFiles();

            //Підключаємо систему маршрутизації
            app.UseRouting();

            //Підключаємо аутентифікацію і авторизацію
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //Реєструємо потрібні маршрути
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");







            await app.RunAsync();
        }
    }
}
