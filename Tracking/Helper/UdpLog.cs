using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Helper
{
    public static class UdpLog
    {
        public static void SendUdpLog(string Message, ApplicationError.Severity SeverityLevel, object Request = null, Exception Ex = null, string Source = "SigmaAPI")
        {
            if (string.IsNullOrEmpty(Message)) return;

            try
            {
                ApplicationError ae = new ApplicationError();
                ae.Source = Source;
                ae.Error = Message;
                ae.SeverityID = (int)SeverityLevel;
                ae.Data = JsonConvert.SerializeObject(Request);
                ae.ErrorDate = DateTime.Now;
                ae.PageURL = string.Empty;

                if (Ex != null)
                {
                    if (string.IsNullOrEmpty(ae.Source)) ae.Source = Ex.Source;
                    ae.StackTrace = Ex.StackTrace.ToString();
                    ae.Exception = Ex.ToString();
                    ae.Message = Ex.Message;
                    ae.InnerException = Ex.InnerException == null ? null : Ex.InnerException.ToString();
                    ae.TargetSite = Ex.TargetSite == null ? null : Ex.TargetSite.ToString();
                }

                string hostname = "192.168.100.165";
#if RELEASE
                int port = 11100;
#else
                int port = 11000;
#endif

                byte[] sendbuf = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(ae));

                using (UdpClient udpClient = new UdpClient(hostname, port))
                {
                    udpClient.Send(sendbuf, sendbuf.Length);
                }
            }
            catch (Exception) { }
        }

        public class ApplicationError
        {
            private int severityID;

            public int Id { get; set; }
            public int ApplicationID { get; set; }
            public int SeverityID
            {
                get { return severityID; }
                set
                {
                    severityID = value < 0 ? (int)Severity.None : value;
                }
            }
            public DateTime ErrorDate { get; set; }
            /// <summary>
            /// Max length: 4000 characters
            /// </summary>
            public string Error { get; set; }
            /// <summary>
            /// Max length: 500 characters
            /// </summary>
            public string PageURL { get; set; }
            /// <summary>
            /// Max length: 6000 characters
            /// </summary>
            public string StackTrace { get; set; }
            /// <summary>
            /// Max length: 6000 characters
            /// </summary>
            public string InnerException { get; set; }
            /// <summary>
            /// Max length: 2000 characters
            /// </summary>
            public string Message { get; set; }
            /// <summary>
            /// Max length: 100 characters
            /// </summary>
            public string Source { get; set; }
            /// <summary>
            /// Max length: 500 characters
            /// </summary>
            public string TargetSite { get; set; }
            /// <summary>
            /// Max length: 1000 characters
            /// </summary>
            public string Data { get; set; }
            /// <summary>
            /// Max length: 6000 characters
            /// </summary>
            public string Exception { get; set; }
            public int DeletedDate { get; set; }

            public static ApplicationError CreateErrorLog(int id, DateTime timeStamp, string error, Severity severity)
            {
                ApplicationError errorLog = new ApplicationError();
                errorLog.Id = id;
                errorLog.ErrorDate = timeStamp;
                errorLog.Error = error;
                errorLog.SeverityID = (int)severity;
                return errorLog;
            }

            public enum Severity
            {
                None = 1,
                Critical = 2,
                Serious = 3,
                Warning = 4,
                Information = 5
            }
        }
    }
}
