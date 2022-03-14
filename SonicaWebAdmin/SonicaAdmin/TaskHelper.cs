using System.Threading;
using System.Threading.Tasks;

namespace SonicaWebAdmin.SonicaAdmin
{
    public static class TaskHelper
    {
        /// <summary>
        /// Завершает таску сразу по приходу отмены.
        /// Оригинальная таска прододлжает работать, и мы ее теряем из контроля
        /// </summary>
        public static T WithAsyncCancelation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var cancelationTask = Task.Run(() => WaitHandle.WaitAny(new[] { cancellationToken.WaitHandle }));

            //ждем либо таску либо отмену
             Task.WhenAny(cancelationTask, task);
            if (cancellationToken.IsCancellationRequested)
            {
                //Таска взбесится от того что ее отменили и исключение не обработали. Поэтому исключения в таске мы игнорируем
                var failedTask = task.ContinueWith(t =>
                {
                    if (t.Exception != null)
                    {
                        //TODO: нужно сделать логировку нормальную
                        //SLog.Log.Error("AsyncCancelation", t.Exception.Flatten(), "Error: ");
                    };
                }, TaskContinuationOptions.OnlyOnFaulted);

                cancellationToken.ThrowIfCancellationRequested();
            }

            return task.Result;
        }
    }
}
