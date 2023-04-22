namespace Backend.Services;

public sealed class MonitorLoop
{
    private readonly IBackgroundTaskQueue _taskQueue;
    private readonly ILogger<MonitorLoop> _logger;
    private readonly CancellationToken _cancellationToken;
    readonly QueueService _service;

    public MonitorLoop(
        IBackgroundTaskQueue taskQueue,
        ILogger<MonitorLoop> logger,
        IHostApplicationLifetime applicationLifetime,
        QueueService service)
    {
        _taskQueue = taskQueue;
        _logger = logger;
        _cancellationToken = applicationLifetime.ApplicationStopping;
        _service = service;
    }

    public void StartMonitorLoop()
    {
        _logger.LogInformation($"{nameof(MonitorAsync)} loop is starting.");

        // Run a console user input loop in a background thread
        Task.Run(() => MonitorAsync());
    }

    private void MonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
        {
            var keyStroke = Console.ReadKey();
            if (keyStroke.Key == ConsoleKey.W)
            {
                // Enqueue a background work item
                // _taskQueue.QueueBackgroundWorkItem(Guid.NewGuid());
                _taskQueue.QueueRequest(BuildWorkItemAsync(_cancellationToken));
                // _service.AssignTaskToExperts();
                // _logger.LogInformation(BuildWorkItemAsync(_cancellationToken).ToString());
            }
            // _taskQueue.QueueBackgroundWorkItem(BuildWorkItemAsync);
        }
    }

    private Guid BuildWorkItemAsync(CancellationToken token)
    {
        if (!token.IsCancellationRequested)
        {
            return Guid.NewGuid();
        }

        return Guid.Empty;
    }
}