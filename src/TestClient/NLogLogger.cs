using System;
using Linker;
using NLog;

namespace TestClient
{
    public class NLogLogger : ILinkerLogger
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Warn(string message)
        {
            Log.Warn(message);
        }

        public void Warn(string message, Exception ex)
        {
            Log.Warn(ex, message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            Log.Error(ex, message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string format, params object[] args)
        {
            Log.Error(format, args);
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            Log.Error(ex, format, args);
        }

        public void Warn(string format, params object[] args)
        {
            Log.Warn(format, args);
        }

        public void Warn(Exception ex, string format, params object[] args)
        {
            Log.Warn(ex, format, args);
        }

        public void Info(string format, params object[] args)
        {
            Log.Info(format, args);
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            Log.Info(ex, format, args);
        }

        public void Debug(string format, params object[] args)
        {
            Log.Debug(format, args);
        }

        public void Debug(Exception ex, string format, params object[] args)
        {
            Log.Debug(ex, format, args);
        }
    }
}
