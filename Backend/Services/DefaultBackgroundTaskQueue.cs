using Backend.Business.ExpertRequest;
using Backend.Models;

namespace Backend.Services
{
	public class DefaultBackgroundTaskQueue : IBackgroundTaskQueue
	{
		private readonly Queue<Request> requestQueue;
		private readonly Queue<Expert> expertQueue;
		readonly IExpertRequest expertRequest;

		public DefaultBackgroundTaskQueue(IExpertRequest expertRequest)
		{
			requestQueue = new Queue<Request>();
			expertQueue = new Queue<Expert>();
			this.expertRequest = expertRequest;
			GetExperts();
			System.Timers.Timer timer = new (interval: 86400);
			timer.Elapsed += ( sender, e ) => GetExperts();
			timer.Start();
		}

		public void GetExperts()
		{
			var experts = expertRequest.GetExperts().Result;
			expertQueue.Clear();
			foreach (var expert in experts)
			{
				expertQueue.Enqueue(expert);
			}
		}

		public void EnqueueRequest(Request request)
		{
			requestQueue.Enqueue(request);
		}

		public Request DequeueRequest()
		{
			return requestQueue.Dequeue();
		}

		public void EnqueueExpert(Expert expert)
		{
			expertQueue.Enqueue(expert);
		}

		public Expert DequeueExpert()
		{
			return expertQueue.Dequeue();
		}

		public bool IsExpertAvailable()
		{
			return expertQueue.Any();
		}

		public bool IsRequestAvailable()
		{
			return requestQueue.Any();
		}
	}
}