namespace Backend.BackgroundServices;

public interface IBackgroundTaskQueue
{
	void QueueBackgroundWorkItem(Func<CancellationToken, ValueTask> workItem);

	ValueTask<Func<CancellationToken, ValueTask>> Dequeue(CancellationToken cancellationToken);
}