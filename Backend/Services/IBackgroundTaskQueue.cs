namespace Backend.Services;

public interface IBackgroundTaskQueue
{
	void EnqueueRequest(Guid workItem);

	Guid DequeueRequest();
	void EnqueueExpert(Guid expertId);

	Guid DequeueExpert();
	bool IsExpertAvailable();
}