
using ConsumeProducts.Extensions;
using ConsumeProducts.Services;
using Refit;

namespace ConsumeProducts
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
            // Add Refit client with Polly policy
            builder.Services.AddRefitClient<IProductAPI>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7298/api"))
                .AddPolicyHandler(PollyPolicies.GetRetryPolicy());
            
            // Register WeatherService
            builder.Services.AddTransient<IProductService, ProductService>();
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
    }
}
