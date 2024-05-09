using ARM_CRUD_API.Data;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;

namespace ARM_CRUD_API
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration config)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "A Simple Crud Restfull service for staffs",
                    Version = "v1",
                    Description = "This Api enables you perform CRUD operations on any Staff of your choice using the in memory database",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Staff Api",
                        Url = new Uri("https://localhost:44310/swagger/index.html")
                    }
                });

            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(config.GetConnectionString("DbConnect")));
            services.AddCors(p => p.AddPolicy("staff", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1.0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }


    }
}
