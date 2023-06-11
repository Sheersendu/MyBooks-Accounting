using Backend.Business;
using Backend.Business.ExpertRequest;
using Backend.Models;

namespace Backend.Services;

public class QueueService
{
	readonly IBackgroundTaskQueue taskQueue;
	readonly ILogger<QueueService> logger;
	readonly IExpertRequest expertRequest;

	public QueueService(
		IBackgroundTaskQueue taskQueue,
		ILogger<QueueService> logger,
		IExpertRequest expertRequest)
	{
		this.taskQueue = taskQueue;
		this.logger = logger;
		this.expertRequest = expertRequest;
	}

	public void StartQueueService()
	{
		AssignRequestToExpert();
	}

	public void AddExpert(Expert expert)
	{
		taskQueue.EnqueueExpert(expert);
		AssignRequestToExpert();
	}
	
	public void AddRequest(Request request)
	{
		taskQueue.EnqueueRequest(request);
		AssignRequestToExpert();
	}

	void AssignRequestToExpert()
	{
		try
		{
			while (taskQueue.IsExpertAvailable() && taskQueue.IsRequestAvailable())
			{
				var expert = taskQueue.DequeueExpert();
				var request = taskQueue.DequeueRequest();
				logger.LogInformation("Request: {task} - Expert: {expert}", request.Req_Name,expert.Exp_ID);
				expertRequest.MapRequestToExpert(expert.Exp_PK, request.Req_PK);
			}
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Error occurred while assigning task.");
		}
	}
}