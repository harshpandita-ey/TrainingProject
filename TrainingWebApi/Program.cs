using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
namespace TrainingWebApi
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
            builder.Services.AddScoped<ITechnologyRepoAsync, EFTechnologyRepoAsync>();
            builder.Services.AddScoped<ITrainingRepoAsync, EFTrainingRepoAsync>();
            builder.Services.AddScoped<IEmployeeRepoAsync, EFEmployeeRepoAsync>();
            builder.Services.AddScoped<ITrainerRepoAsync, EFTrainerRepoAsync>();
            builder.Services.AddScoped<ITraineeRepoAsync, EFTraineeRepoAsync>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
