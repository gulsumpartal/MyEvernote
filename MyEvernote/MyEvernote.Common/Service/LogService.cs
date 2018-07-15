using System;

namespace MyEvernote.Common.Service
{
    public class LogService
    {
        public void Debug(Exception ex, string message)
        {
            log4net.LogManager.GetLogger("DebugLogger").Debug(message, ex);
        }

        public void Debug(string message)
        {
            log4net.LogManager.GetLogger("DebugLogger").Debug(message);
        }

        public void Info(Exception ex, string message)
        {
            log4net.LogManager.GetLogger("InfoLogger").Info(message, ex);
        }

        public void Info(string message)
        {
            log4net.LogManager.GetLogger("InfoLogger").Info(message);
        }

        public void Warn(Exception ex, string message)
        {
            log4net.LogManager.GetLogger("WarnLogger").Warn(message, ex);
        }

        public void Warn(string message)
        {
            log4net.LogManager.GetLogger("WarnLogger").Warn(message);
        }

        public void Error(Exception ex, string message)
        {
            log4net.LogManager.GetLogger("ErrorLogger").Error(message, ex);
        }

        public void Error(string message)
        {
            log4net.LogManager.GetLogger("ErrorLogger").Error(message);
        }

        public void Fatal(Exception ex, string message)
        {
            log4net.LogManager.GetLogger("FatalLogger").Fatal("Fatal Message", ex);
        }

        public void Fatal(string message)
        {
            log4net.LogManager.GetLogger("FatalLogger").Fatal(message);
        }
    }
}
