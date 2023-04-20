namespace Backend.BackgroundServices;

public interface IBackgroundTaskQueue
{
	void QueueBackgroundWorkItem(Guid workItem);

	Guid Dequeue();
}