namespace TransactionAPI.Helpers;

public static class LogsHelper
{
    public static void InfoLog(string message, string methodName)
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(methodName);
        logger.Info(message);
    }

    public static void ErrorLog(string message, string methodName)
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(methodName);
        logger.Error(message);
    }

    public static void WarningLog(string message, string methodName)
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(methodName);
        logger.Warn(message);
    }
}