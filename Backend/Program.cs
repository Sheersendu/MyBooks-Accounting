using Backend.BackgroundServices;
using Backend.Business;
using Backend.Context;

class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
		builder.Services.AddSingleton<DapperContext>(); 
		builder.Services.AddControllers();
		builder.Services.AddHostedService<QueuedHostedService>();
		builder.Services.AddSingleton<IBackgroundTaskQueue>(_ => 
		{
			if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
			{
				queueCapacity = 100;
			}

			return new DefaultBackgroundTaskQueue(queueCapacity);
		});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddSingleton<IExpertRepository, ExpertRepository>();

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