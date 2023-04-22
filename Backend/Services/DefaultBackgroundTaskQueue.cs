namespace Backend.Services
{
	public class DefaultBackgroundTaskQueue : IBackgroundTaskQueue
	{
		private readonly Queue<Guid> queue;

		public DefaultBackgroundTaskQueue(int queueCapacity)
		{
			queue = new Queue<Guid>();
			for (var i = 0; i < 1; i++)
			{
				queue.Enqueue(Guid.NewGuid());
			}
		}

		public void QueueRequest(Guid workItem)
		{
			queue.Enqueue(workItem);
		}

		public Guid Dequeue()
		{
			return queue.Count > 0 ? queue.Dequeue() : Guid.Empty;
		}
	}
}