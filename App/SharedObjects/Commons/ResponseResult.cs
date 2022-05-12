using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Commons
{
    public class ResponseResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public ResponseResult() { }
        public ResponseResult(int statusCode)
        {
            StatusCode = statusCode;
        }
        public ResponseResult(int statusCode, string message)
        {
            StatusCode=statusCode;
            Message = message;
        }
        public ResponseResult(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

    }
}
