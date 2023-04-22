using Backend.Business;
using Backend.Models;

namespace Backend.Services;

public class QueueService
{
	readonly IBackgroundTaskQueue taskQueue;
	readonly ILogger<QueueService> logger;
	readonly IExpertRepository expertRepository;
	Task<IEnumerable<Expert>>? experts;

	public QueueService(
		IBackgroundTaskQueue taskQueue,
		ILogger<QueueService> logger,
		IExpertRepository expertRepository)
	{
		this.taskQueue = taskQueue;
		this.logger = logger;
		this.expertRepository = expertRepository;
	}

	public void StartQueueService()
	{
		if (experts == null)
		{
			GetExpertsList();
		}
	}

	private void GetExpertsList()
	{
		experts = expertRepository.GetExperts();
		foreach (var expert in experts.Result.ToList())
		{
			Console.WriteLine(expert.EXP_ID);
			AssignTaskToExperts(expert);
		}
	}

	private void AssignTaskToExperts(Expert expert)
	{
		//Make business layer calls here for assignment
		logger.LogInformation(
			$"{nameof(QueueService)} is running.{Environment.NewLine}" +
			$"{Environment.NewLine}");
		try
		{
			logger.LogInformation("Request: {task} - Expert: {expert}", taskQueue.Dequeue(),expert.EXP_ID);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Error occurred while assigning task.");
		}
	}
}