using Quanlykho.Interfaces;
using System;
using System.Threading.Tasks;

namespace Quanlykho.Utilities
{
    public static class TaskUtilities
    {
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void

        //public static async void FireAndForgetSafeAsync(this Task task, Action<Exception> handleErrorAction = null)
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            //try
            //{
            //    await task.ConfigureAwait(true);
            //}
            //catch (Exception ex)
            //{
            //    handleErrorAction?.Invoke(ex);
            //}
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}