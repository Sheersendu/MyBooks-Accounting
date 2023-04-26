namespace Backend.Services
{
	public class DefaultBackgroundTaskQueue : IBackgroundTaskQueue
	{
		private readonly Queue<Guid> requestqueue;
		private readonly Queue<Guid> expertqueue;

		public DefaultBackgroundTaskQueue(int queueCapacity)
		{
			requestqueue = new Queue<Guid>();
			expertqueue = new Queue<Guid>();
			for (var i = 0; i < 1; i++)
			{
				requestqueue.Enqueue(Guid.NewGuid());
			}
		}

		public void EnqueueRequest(Guid workItem)
		{
			requestqueue.Enqueue(workItem);
		}

		public Guid DequeueRequest()
		{
			return requestqueue.Count > 0 ? requestqueue.Dequeue() : Guid.Empty;
		}

		public void EnqueueExpert(Guid expertId)
		{
			expertqueue.Enqueue(expertId);
		}

		public Guid DequeueExpert()
		{
			return expertqueue.Count > 0 ? expertqueue.Dequeue() : Guid.Empty;
		}

		public bool IsExpertAvailable()
		{
			return expertqueue.Any();
		}
	}
}