using System;

namespace Linker
{
    public class SimpleConsoleLogger : ILinkerLogger
    {
        private readonly string _moduleName;

        public SimpleConsoleLogger(string moduleName)
        {
            _moduleName = moduleName;
        }

        public void Info(string message)
        {
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
        }

        public void Warn(string message)
        {
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
        }

        public void Warn(string message, Exception ex)
        {
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{ex.GetBaseException().Message}");
        }

        public void Error(string message)
        {
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
        }

        public void Error(string message, Exception ex)
        {
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{ex.GetBaseException().Message}");
        }

        public void Debug(string message)
        {
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
        }

        private void WriteMessageWithArguments(string message, object[] args, Exception exc)
        {
            var argsMessage = args != null ? string.Join(" ", args) : "";

            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{message}");
            Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{argsMessage}");
            if (exc != null)
                Console.WriteLine($"{DateTime.Now:F}|{_moduleName}|{exc.GetBaseException().Message}");
        }

        public void Error(string format, params object[] args) => WriteMessageWithArguments(format, args, null);

        public void Error(Exception ex, string format, params object[] args) => WriteMessageWithArguments(format, args, ex);
        public void Warn(string format, params object[] args) => WriteMessageWithArguments(format, args, null);
        public void Warn(Exception ex, string format, params object[] args) => WriteMessageWithArguments(format, args, ex);
        public void Info(string format, params object[] args) => WriteMessageWithArguments(format, args, null);
        public void Info(Exception ex, string format, params object[] args) => WriteMessageWithArguments(format, args, ex);
        public void Debug(string format, params object[] args) => WriteMessageWithArguments(format, args, null);
        public void Debug(Exception ex, string format, params object[] args) => WriteMessageWithArguments(format, args, ex);
    }
}
