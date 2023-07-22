using ESNLib.Tools;
using System;
using System.Diagnostics;

namespace StockManagerDB
{
    internal class LoggerClass
    {
        public const Logger.LogLevels MinLevelFilter = Logger.LogLevels.All;

        public static Logger logger = new Logger(
            Logger.GetDefaultLogPath("ESN", "StockManager", "log")
        )
        {
            WriteMode = Logger.WriteModes.Write,
            FilenameMode = Logger.FilenamesModes.FileName_CurrentPrevious,
            PrefixMode = Logger.PrefixModes.RunTime,
            LogLeveFilter = MinLevelFilter,
        };

        public static void Init()
        {
            if (!logger.Enable())
                throw new InvalidOperationException("Unable to start logger");
#if DEBUG
            //Process.Start(logger.FileOutputPath);
#endif
        }

        public static bool Write(string data)
        {
            return Write(data, Logger.LogLevels.Debug);
        }

        public static bool Write(string data, Logger.LogLevels logLevel)
        {
            return logger.Write(data, logLevel);
        }

        public static bool WriteCustom(string data, string logLevelName)
        {
            return logger.Write(data, logLevelName);
        }
    }
}
