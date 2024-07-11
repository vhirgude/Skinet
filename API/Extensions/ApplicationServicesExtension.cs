using API.Errors;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Extensions;
public static class ApplicationservicesExtension
{
    public static IServiceCollection AddApplicationservices(this IServiceCollection services
    ,IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(opt=> {
            opt.UseSqlite(config.GetConnectionString("dbConn"));
        });
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<ApiBehaviorOptions>(option => {
            option.InvalidModelStateResponseFactory=actioncontext =>
            {
                var error=actioncontext.ModelState
                .Where(e=>e.Value.Errors.Count>0)
                .SelectMany(p=>p.Value.Errors)
                .Select(e=>e.ErrorMessage);

                var errorresponse=new ApiValidationErrorResponse()
                {
                    Errors=error
                };
                return new BadRequestObjectResult(errorresponse);
            };
        });

        services.AddCors(opt=>
        {
            opt.AddPolicy("CorsPolicy",policy=>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("https://localhost:4200");

            });

        });
        return services;
    }

}
