using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Family.Db;
using Microsoft.EntityFrameworkCore;
using Family.Web.Utilities;
using Family.Logic.ParentsService;
using Family.Logic.ChildrenService;
using Family.Logic.GenusService;
using Family.WebDb.ParentsRepository;
using Family.WebDb.ChildrenRepository;
using Family.WebDb.GenusRepository;

namespace Family.Web
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
            services.AddScoped<IParentsService, ParentsService>();
            services.AddScoped<IParentsRepository, ParentsRepository>();

            services.AddScoped<IChildrenService, ChildrenService>();
            services.AddScoped<IChildrenRepository, ChildrenRepository>();

            services.AddScoped<IGenusService, GenusService>();
            services.AddScoped<IGenusRepository, GenusRepository>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddCors(options =>
            {
                options.AddPolicy("devCors", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddDbContext<FamilyContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("Family");
                options.UseSqlServer(connectionString);
            });

            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Family.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Family.Web v1"));
                app.UseCors("devCors");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            EnsureDbCreated(app);
        }

        private void EnsureDbCreated(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            var scope = scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<FamilyContext>();

            context!.Database.EnsureCreated();
        }
    }
}
