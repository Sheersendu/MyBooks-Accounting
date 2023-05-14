using System.Timers;
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
			// var timer = new System.Timers.Timer();
			// timer.Interval = 86400;
			// timer.Elapsed += GetExperts;
			// timer.Start();
		}

		public void GetExperts()
		{
			expertQueue.Clear();
			var experts = expertRequest.GetExperts().Result;
			foreach (var expert in experts)
			{
				expertQueue.Enqueue(expert);
			}

			Console.WriteLine("Get Experts:"+expertQueue.Count);
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
			Console.WriteLine("Enqueue:"+expertQueue.Count);
		}

		public Expert DequeueExpert()
		{
			Console.WriteLine("Dequeue:"+expertQueue.Count);
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