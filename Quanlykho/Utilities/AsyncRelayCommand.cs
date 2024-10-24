using Quanlykho.Interfaces;
using System;
using System.Threading.Tasks;

namespace Quanlykho.Utilities
{
    public class AsyncRelayCommand<T> : AsyncCommand<T>
    {
        public AsyncRelayCommand(Func<T, Task> execute, Func<T, bool> canExecute = null, 
            IErrorHandler errorHandler = null) : base(execute, canExecute, errorHandler)
        {
        }
    }
}