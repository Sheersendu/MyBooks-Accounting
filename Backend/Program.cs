using Backend.Business;
using Backend.Business.Customer;
using Backend.Business.CustomerRequest;
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
		builder.Services.AddControllers();
		builder.Services.AddSingleton<QueueService>();
		builder.Services.AddSingleton<IBackgroundTaskQueue,DefaultBackgroundTaskQueue>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddSingleton<IExpertRepository, ExpertRepository>();
		builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
		builder.Services.AddSingleton<IRequestRepository, RequestRepository>();
		builder.Services.AddSingleton<IExpertRequest,ExpertRequestRepository>();
		builder.Services.AddSingleton<ICustomerRequest,CustomerRequestRepository>();

		var app = builder.Build();
		
		var queueService = app.Services.GetRequiredService<QueueService>();
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