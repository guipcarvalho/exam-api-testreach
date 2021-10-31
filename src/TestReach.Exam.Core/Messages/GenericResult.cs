using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Enums;

namespace TestReach.Exam.Core.Messages
{
    public class GenericResult
    {
        public Response ResponseCode { get; set; }
        public object Data { get; set; }

        public GenericResult(Response responseCode, object data)
        {            
            ResponseCode = responseCode;
            Data = data;
        }
    }
}
