using System;
using NLog;

namespace Epam.Wunderlist.Logger
{
    public static class Log
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        public static void LogError(Exception ex)
        {
            Logger.Error(ex, "Stack trace: " + ex.StackTrace + "; \r\n Message : " + ex.Message, null);
        }

        public static void LogInfo(string message)
        {
            Logger.Info(message);
        }
    }
}
