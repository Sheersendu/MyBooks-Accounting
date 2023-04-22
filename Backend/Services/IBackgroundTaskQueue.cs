namespace Backend.Services;

public interface IBackgroundTaskQueue
{
	void QueueRequest(Guid workItem);

	Guid Dequeue();
}