using Backend.Models;

namespace Backend.Services;

public interface IBackgroundTaskQueue
{
	void GetExperts();
	void EnqueueRequest(Request request);

	Request DequeueRequest();
	void EnqueueExpert(Expert expert);

	Expert DequeueExpert();
	bool IsExpertAvailable();
	bool IsRequestAvailable();
}