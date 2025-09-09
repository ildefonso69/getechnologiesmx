using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

using TestSoftwareDeveloper.Extensions;


namespace TestSoftwareDeveloper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        

            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            builder.Services.ConfigureDbContext();

                 builder.Services.ConfigureCors();

            builder.Services.ConfigureCors();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureRepositoryWrapper();


           
         
            builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseDeveloperExceptionPage();

            }
            else
                app.UseHsts();


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            // Configure the HTTP request pipeline.

            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
