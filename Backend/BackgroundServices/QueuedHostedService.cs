namespace Backend.BackgroundServices;

public class QueuedHostedService : BackgroundService
{
	private readonly IBackgroundTaskQueue _taskQueue;
	private readonly ILogger<QueuedHostedService> _logger;
	private int experts;

	public QueuedHostedService(
		IBackgroundTaskQueue taskQueue,
		ILogger<QueuedHostedService> logger) =>
		(_taskQueue, _logger, experts) = (taskQueue, logger, 5);

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation(
			$"{nameof(QueuedHostedService)} is running.{Environment.NewLine}" +
			$"{Environment.NewLine}Tap W to add a work item to the " +
			$"background queue.{Environment.NewLine}");
		return ProcessTaskQueue(stoppingToken);
	}

	public Task ProcessTaskQueue(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested && experts>0)
		{
			experts -= 1;
			// _logger.LogInformation(experts.ToString());
			try
			{
				_logger.LogInformation("Queued Service "+_taskQueue.Dequeue());
			}
			catch (OperationCanceledException)
			{
				// Prevent throwing if stoppingToken was signaled
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred executing task work item.");
			}
		}

		return Task.CompletedTask;
	}

	public override async Task StopAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation(
			$"{nameof(QueuedHostedService)} is stopping.");

		await base.StopAsync(stoppingToken);
	}
}