using Microsoft.EntityFrameworkCore;
using ProductMicroService.Data;
using ProductMicroService.Repository;
using ProductMicroService.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        AddDependendencyInjectionObjects(builder);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<DataContext>(options => options
                        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    );

        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void AddDependendencyInjectionObjects(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
        builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
    }
}