
using AspektAssignment.Helpers.DependencyInjectionHelper;
using AspektAssignment.Helpers.FluentValidationHelper;
using Serilog;


namespace AspektAssignment.Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add fluent validation and register the validators
            FluentValidationHelper.RegisterFluentValidation(builder.Services);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            DependencyInjectionHelper.InjectDbContext(builder.Services, builder.Configuration);
            DependencyInjectionHelper.InjectRepositories(builder.Services);
            DependencyInjectionHelper.InjectServices(builder.Services);


            builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(builder.Configuration));
            

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
