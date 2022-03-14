using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tracking.Models
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }

        [JsonProperty(Order = 99999)]
        public List<ResponseError> Errors { get; set; }
    }

    public class ResponseError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool PublicDisplay { get; set; }

        public ResponseError() { }

        public ResponseError(string Code, string Message, bool PublicDisplay = false)
        {
            this.Code = Code;
            this.Message = Message;
            this.PublicDisplay = PublicDisplay;
        }
    }
}
