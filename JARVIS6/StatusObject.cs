using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JARVIS6
{
    public enum StatusCode
    {
        SUCCESS,
        FAILURE
    }
    public class StatusObject
    {
        public StatusCode Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }
        public dynamic UDDynamic { get; set; }
        public StatusObject()
        {
            this.Status = StatusCode.SUCCESS;
        }
        public StatusObject(StatusCode Status, string ErrorCode, string ErrorMessage, string ErrorStackTrace)
        {
            this.Status = Status;
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = ErrorMessage;
            this.ErrorStackTrace = ErrorStackTrace;
            this.UDDynamic = null;
        }
        public StatusObject(Exception ex, string ErrorCode)
        {
            this.Status = StatusCode.FAILURE;
            this.ErrorCode = ErrorCode;
            this.ErrorMessage = ex.Message;
            this.ErrorStackTrace = ex.ToString();
            this.UDDynamic = null;
        }
    }
}
