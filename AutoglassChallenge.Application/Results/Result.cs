using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassChallenge.Application.Results
{
    public class Result
    {
        public int ResultCode { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }

        public Result(int resultCode, string message, bool success, object data)
        {
            ResultCode = resultCode;
            Message = message;
            Success = success;
            Data = data;
        }
    }
}
