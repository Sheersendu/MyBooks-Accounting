using System.Threading.Channels;

namespace Backend.BackgroundServices
{
	public class DefaultBackgroundTaskQueue : IBackgroundTaskQueue
	{
		private readonly Channel<Func<CancellationToken, ValueTask>> _queue;

		public DefaultBackgroundTaskQueue(int queueCapacity)
		{
			// Keeping queue size as 100 as default
			BoundedChannelOptions options = new(queueCapacity)
			{
				FullMode = BoundedChannelFullMode.Wait
			};
			_queue = Channel.CreateBounded<Func<CancellationToken, ValueTask>>(options);
		}

		public void QueueBackgroundWorkItem(Func<CancellationToken, ValueTask> workItem)
		{
			if (workItem is null)
			{
				throw new ArgumentNullException(nameof(workItem));
			}

			_queue.Writer.WriteAsync(workItem);
		}

		public ValueTask<Func<CancellationToken, ValueTask>> Dequeue(CancellationToken cancellationToken)
		{
			var workItem = _queue.Reader.ReadAsync(cancellationToken);
			return workItem;
		}
	}
}