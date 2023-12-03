using Microsoft.EntityFrameworkCore;
using OrderMicroService.Data;
using OrderMicroService.Repository;
using OrderMicroService.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        AddDependencyInjectionObjects(builder);

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
    private static void AddDependencyInjectionObjects(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductsInOrderService, ProductsInOrderService>();
        builder.Services.AddScoped<IProductsInOrderRepository, ProductsInOrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    }
}