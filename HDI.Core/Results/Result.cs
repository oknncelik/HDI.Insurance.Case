using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Core.Results
{
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }

    public class Result
    {
        public bool IsSuccess { get; set; } = true;
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
