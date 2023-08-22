using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProductBox_ExerciseSolution.DBContext;
using ProductBox_ExerciseSolution.Interfaces;
using ProductBox_ExerciseSolution.CustomerRepository;


namespace ProductBox_ExerciseSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

         
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable MVC
            services.AddControllers();
            // Database Connection Setting
            services.AddDbContext<CustomerContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // 
            services.AddTransient<ICustomer, RepoCustomer>();
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
    }
}