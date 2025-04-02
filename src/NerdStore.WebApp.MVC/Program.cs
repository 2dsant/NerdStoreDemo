using NerdStoreDemo.Catalogo.Application.AutoMapper;
using NerdStoreDemo.WebApp.MVC.Setup;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NerdStoreDemo.WebApp.MVC.Data;
using System.Reflection;
using MediatR;
using NerdStoreDemo.Catalogo.Data;
using System.Configuration;
using NerdStoreDemo.Vendas.Data;
using NerdStoreDemo.Pagamentos.Data;

namespace NerdStoreDemo.WebApp.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<CatalogoContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<VendasContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<PagamentoContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), 
                typeof(ViewModelToDomainMappingProfile));

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.RegisterServices();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Vitrine}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
