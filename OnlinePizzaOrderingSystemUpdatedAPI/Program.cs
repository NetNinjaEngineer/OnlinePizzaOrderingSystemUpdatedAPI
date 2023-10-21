
using Microsoft.EntityFrameworkCore;
using OnlinePizzaOrderingSystemUpdatedAPI.Contracts;
using OnlinePizzaOrderingSystemUpdatedAPI.Data;
using OnlinePizzaSystemAPI.Services;

namespace OnlinePizzaOrderingSystemUpdatedAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
          );

            builder.Services.AddScoped<IPizzaService, PizzaService>();
            builder.Services.AddScoped<IToppingService, ToppingService>();
            builder.Services.AddScoped<IStoreService, StoreService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<IDeliveryDriverService, DeliveryDriverService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<IIngredientService, IngredientService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ICouponService, CouponService>();

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}