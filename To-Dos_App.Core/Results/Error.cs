using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Dos_App.Core.Results
{
    public class Error
    {
        public string message { get; private set; }
        public int statusCode { get; private set; }
        public Error(string Message, int StatusCode)
        {
            message = Message;
            statusCode = StatusCode;
        }
    }
}
