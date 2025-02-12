﻿namespace igreja.Domain.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(T data, bool success = true, string message = "Operação realizada com sucesso")
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ApiResponse(string message, bool success = false)
        {
            Success = success;
            Message = message;
            Data = default;
        }
    }
}
