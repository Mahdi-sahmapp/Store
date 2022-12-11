using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ApiToReturn
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string Detail { get; set; }
        public List<string> Messages { get; set; } = new();

        public ApiToReturn()
        {

        }

        public ApiToReturn(string message)
        {
            Message = message;
            Messages.Add(message);
        }

        public ApiToReturn(int statuscode, string message)
        {
            Message = message;
            Messages.Add(message);
            StatusCode = statuscode;
        }

        public ApiToReturn(int statuscode,List<string>messages)
        {
            StatusCode = statuscode;
            Messages = messages;
        }
        public ApiToReturn(int statuscode, List<string> messages, string detail)
        {
            StatusCode = statuscode;
            Messages = messages;
            Detail = detail;
        }
        public ApiToReturn(int statuscode, string message, string detail)
        {
            StatusCode = statuscode;
            Message = message;
            Messages.Add(message);
            Detail = detail;
        }

        public ApiToReturn(int statuscode, string message,List<string>messages ,string detail)
        {
            StatusCode = statuscode;
            Message = message;
            Messages = messages;
            Detail = detail;
        }
    }
}
