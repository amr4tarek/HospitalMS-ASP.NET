﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Helpers
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static Result<T> SuccessResult(T data, string message = "")
        {
            return new Result<T> { Success = true, Message = message, Data = data };
        }

        public static Result<T> FailureResult(string message)
        {
            return new Result<T> { Success = false, Message = message, Data = default(T) };
        }
    }
}
