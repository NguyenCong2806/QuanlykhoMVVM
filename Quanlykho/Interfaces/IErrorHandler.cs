using System;

namespace Quanlykho.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}