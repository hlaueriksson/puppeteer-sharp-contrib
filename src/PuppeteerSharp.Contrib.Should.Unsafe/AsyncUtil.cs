using System;
using System.Threading;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Should
{
    // https://www.ryadel.com/en/asyncutil-c-helper-class-async-method-sync-result-wait/

    /// <summary>
    /// Helper class to run async methods within a sync process.
    /// </summary>
    internal static class AsyncUtil
    {
        private static readonly TaskFactory _taskFactory = new
            TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        /// <summary>
        /// Executes an async Task method which has a void return value synchronously
        /// USAGE: AsyncUtil.RunSync(() => AsyncMethod());
        /// </summary>
        /// <param name="task">Task method to execute</param>
        public static void RunSync(Func<Task> task)
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
            => _taskFactory
                .StartNew(task)
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Executes an async Task<T> method which has a T return type synchronously
        /// USAGE: T result = AsyncUtil.RunSync(() => AsyncMethod<T>());
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="task">Task<T> method to execute</param>
        /// <returns></returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> task)
#pragma warning disable CA2008 // Do not create tasks without passing a TaskScheduler
            => _taskFactory
                .StartNew(task)
#pragma warning restore CA2008 // Do not create tasks without passing a TaskScheduler
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
