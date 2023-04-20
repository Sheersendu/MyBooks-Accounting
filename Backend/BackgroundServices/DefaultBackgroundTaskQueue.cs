using System.Threading.Channels;

namespace Backend.BackgroundServices
{
	public class DefaultBackgroundTaskQueue : IBackgroundTaskQueue
	{
		private readonly Queue<Guid> _queue;

		public DefaultBackgroundTaskQueue(int queueCapacity)
		{
			_queue = new Queue<Guid>();
			// for (var i = 0; i < 10; i++)
			// {
			// 	_queue.Enqueue(Guid.NewGuid());
			// }
		}

		public void QueueBackgroundWorkItem(Guid workItem)
		{
			_queue.Enqueue(workItem);
		}

		public Guid Dequeue()
		{
			if (_queue.Count > 0)
			{
				return _queue.Dequeue();
			}

			return Guid.Empty;
		}
	}
}