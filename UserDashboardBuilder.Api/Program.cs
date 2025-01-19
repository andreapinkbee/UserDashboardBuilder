
using System;
using System.Net.Http;
using Polly;
using Polly.Extensions.Http;
using UserDashboardBuilder.Infrastructure;


namespace UserDashboardBuilder.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar acceso a appsettings.json

            var configuration = builder.Configuration;

            // Agregar HttpClient con Circuit Breaker y base URL desde appsettings.json

            builder.Services.AddHttpClient("ExternalApi", client =>
            {
                // Configurar base URL desde appsettings
                client.BaseAddress = new Uri(configuration["ApiSettings:ExternalApiBaseUrl"]);
            })
            .AddPolicyHandler(GetCircuitBreakerPolicy()); 


            builder.Services.AddTransient<ExternalApiService>();

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
            {
                return HttpPolicyExtensions
                    .HandleTransientHttpError() // Manejar errores transitorios
                    .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)); // Rompe después de 5 fallos y espera 30 segundos
            }

        }
    }
}
