using System;
using System.Threading;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    // https://www.ryadel.com/en/asyncutil-c-helper-class-async-method-sync-result-wait/
    internal static class AsyncUtil
    {
        private static readonly TaskFactory _taskFactory = new
            TaskFactory(
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

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
