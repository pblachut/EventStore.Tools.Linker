using System;

namespace Linker
{
    public interface ILinkerLogger
    {
        void Info(string message);
        void Warn(string message);
        void Warn(string message, Exception ex);
        void Error(string message);
        void Error(string message, Exception ex);
        void Debug(string message);
        void Error(string format, params object[] args);
        void Error(Exception ex, string format, params object[] args);
        void Warn(string format, params object[] args);
        void Warn(Exception ex, string format, params object[] args);
        void Info(string format, params object[] args);
        void Info(Exception ex, string format, params object[] args);
        void Debug(string format, params object[] args);
        void Debug(Exception ex, string format, params object[] args);
    }
}
