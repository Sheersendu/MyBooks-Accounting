using System.Text;
using Backend.Business;
using Backend.Business.Customer;
using Backend.Business.CustomerRequest;
using Backend.Business.ExpertRequest;
using Backend.Business.Request;
using Backend.Business.User;
using Backend.Context;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

static class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		ConfigurationManager configuration = builder.Configuration;
		builder.Services.AddCors(options =>
		{
			options.AddPolicy(name: "MyPolicy",
				policy =>
				{
					policy.AllowAnyHeader().AllowAnyMethod();
					policy.WithOrigins("http://localhost:8080");
				});
		});

// Add services to the container.
		builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = configuration["JWT:ValidAudience"],
					ValidIssuer = configuration["JWT:ValidIssuer"],
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
				};
			});
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
		builder.Services.AddSingleton<IUserRepository, UserRepository>();

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
		app.UseCors("MyPolicy");

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}