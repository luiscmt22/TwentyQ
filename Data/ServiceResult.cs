using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyQ.Data
{
    public class ServiceResult<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Result { get; set; }

        public static ServiceResult<T> Success(T result)
        {
            return new ServiceResult<T>
            {
                IsSuccess = true,
                Result = result
            };
        }

        public static ServiceResult<T> Failure(string message)
        {
            return new ServiceResult<T>
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
