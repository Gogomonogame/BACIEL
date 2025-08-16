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
            

            //ϳ�������� � ������ appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            //������������ ������ Project � ��'����� �����
            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            //ϳ��������� ��������� ��
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

            //����������� Identity �������
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //����������� Auth cookie
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myOrganizationAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });



            //ϳ�������� ���������� ����������
            builder.Services.AddControllersWithViews();

            //ϳ��������� ����
            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            //������� ������������
            WebApplication app = builder.Build();

            //!!!!! ������� ��������� middleware ��������, ���� ������ ������������ �������� �� �����

            //³����� ������������� ����������
            app.UseSerilogRequestLogging();

            //��� �������� ������� ���������
            if(app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //ϳ�������� ������������ ��������� ����� wwwroot/
            app.UseStaticFiles();

            //ϳ�������� ������� �������������
            app.UseRouting();

            //ϳ�������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //�������� ������ ��������
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");







            await app.RunAsync();
        }
    }
}
