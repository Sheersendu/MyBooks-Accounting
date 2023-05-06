using Backend.Business;
using Backend.Business.ExpertRequest;
using Backend.Business.Request;
using Backend.Context;
using Backend.Services;

static class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
		builder.Services.AddSingleton<DapperContext>();
		builder.Services.AddSingleton<MonitorService>();
		builder.Services.AddControllers();
		builder.Services.AddSingleton<QueueService>();
		builder.Services.AddSingleton<IBackgroundTaskQueue,DefaultBackgroundTaskQueue>();
		// builder.Services.AddSingleton<IBackgroundTaskQueue>(_ => 
		// {
		// 	if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
		// 	{
		// 		queueCapacity = 100;
		// 	}
		//
		// 	return new DefaultBackgroundTaskQueue(queueCapacity);
		// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddSingleton<IExpertRepository, ExpertRepository>();
		builder.Services.AddSingleton<IRequestRepository, RequestRepository>();
		builder.Services.AddSingleton<IExpertRequest,ExpertRequestRepository>();

		var app = builder.Build();
		
		// MonitorLoop monitorLoop = app.Services.GetRequiredService<MonitorLoop>();
		// monitorLoop.StartMonitorLoop();
		QueueService queueService = app.Services.GetRequiredService<QueueService>();
		queueService.StartQueueService();
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