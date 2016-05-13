using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSWebApp.Common
{
    public class OperationResult
    {
        public OperationResult()
        {
            MessageList = new List<string>();
            Success = true;
        }

        public bool Success { get; set; }
        public List<string> MessageList { get; set; }
    }
}