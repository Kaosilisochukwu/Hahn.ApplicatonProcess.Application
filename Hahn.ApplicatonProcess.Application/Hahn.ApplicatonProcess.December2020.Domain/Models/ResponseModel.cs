using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Models
{
    public class ResponseModel
    {
        public ResponseModel(int statusCode, string Message, object data)
        {
            StatusCode = statusCode;
            this.Message = Message;
            Data = data;
        }

        public int StatusCode { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
