using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Logging
{
    public class Log : ILog, ITraceWriter
    {
        #region Static Constructors

        static Log()
        {
        }

        public static bool DebugLoggingOn { get; set; }

        #endregion

        #region ILog Members

        public void Verbose(object message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            if (DebugLoggingOn)
            {
                Verbose(message, null, memberName, sourceFilePath, sourceLineNumber);
            }
        }

        public void Verbose(object message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            if (DebugLoggingOn)
            {
                //string name = new System.Diagnostics.StackTrace().GetFrames()[1].GetMethod().DeclaringType.Name + "." + memberName;
              //  UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Information, null, exception);
            }
        }

        public void Debug(object message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            if (DebugLoggingOn)
            {
               // UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Information);
            }
        }

        public void Debug(object message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            if (DebugLoggingOn)
            {
                //UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Information, null, exception);
            }
        }

        public void Error(object message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
           // UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Serious);
        }

        public void Error(object message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            //UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Serious, null, exception);
        }

        public void Fatal(object message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
           // UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Critical);
        }

        public void Fatal(object message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
           // UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Critical, null, exception);
        }

        public void Info(object message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            //UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Information);
        }

        public void Info(object message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
           //UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Information, null, exception);
        }

        public void Warn(object message, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            //UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Warning);
        }

        public void Warn(object message, Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            //UdpLog.SendUdpLog(string.Empty, Convert.ToString(message), (int)ApplicationError.Severity.Warning, null, exception);
        }

        #endregion

        #region ITraceWriter Members

        public System.Diagnostics.TraceLevel LevelFilter
        {
            get { return System.Diagnostics.TraceLevel.Verbose; }
        }

        public void Trace(System.Diagnostics.TraceLevel level, string message, Exception ex)
        {
            switch (level)
            {
                case System.Diagnostics.TraceLevel.Error:
                    this.Error(message, ex);
                    break;
                case System.Diagnostics.TraceLevel.Warning:
                    this.Warn(message, ex);
                    break;
                case System.Diagnostics.TraceLevel.Info:
                    this.Info(message, ex);
                    break;
                case System.Diagnostics.TraceLevel.Verbose:
                    this.Debug(message, ex);
                    break;
            }
        }

        #endregion
    }
}
