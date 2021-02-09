using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Logging
{
    public class LogModel
    {
        public LogModel()
        {
            Timestamp = DateTime.Now;
        }
        public DateTime Timestamp { get; private set; }
        public string Method { get; set; }
        public int RequestStatus { get; set; }
        public string Message { get; set; }
        public long? ElapsedMiliseconds { get; set; }
        public Exception Exception { get; set; }
        public int MyProperty { get; set; }
    }
}
