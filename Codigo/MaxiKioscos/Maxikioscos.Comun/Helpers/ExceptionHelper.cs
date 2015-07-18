using log4net;
using System;
using System.Diagnostics;
using log4net.Core;

namespace Maxikioscos.Comun.Helpers
{
    public static class ExceptionHelper
    {
        public static Exception GetInnerException(Exception ex)
        {
            if (ex.InnerException == null)
                return ex;
            return GetInnerException(ex.InnerException);
        }

        public static int LineNumber(Exception ex)
        {
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            return line;
        }

        public static void LogWithFormat(Exception ex)
        {
            LogManager.GetLogger("errors").Error(String.Format("Line Number: {0}", LineNumber(ex)));
            LogManager.GetLogger("errors").Error(String.Format("Error: {0}", GetInnerException(ex).Message));
            LogManager.GetLogger("errors").Error(ex);
        }
    }
}
