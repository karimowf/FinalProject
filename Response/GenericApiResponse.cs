using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project.Shared
{
    public class GenericApiResponse<T>
    {
        public T? Data { get; set; }

        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccessfully { get; set; }

        public List<string>? Errors { get; set; }

        public T? GenericError { get; set; }

        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public static GenericApiResponse<T> Success(T data, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfully = true
            };
        }

        public static GenericApiResponse<T> Success(T data, int statusCode, bool isSuccess)
        {
            return new GenericApiResponse<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfully = true,
                IsSuccess = isSuccess
            };
        }

        public static GenericApiResponse<T> Success(string message, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Message = message,
                StatusCode = statusCode,
                IsSuccess = true,
                IsSuccessfully = true
            };
        }

        public static GenericApiResponse<T> Success(int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSuccessfully = true,
                IsSuccess = true
            };
        }

        public static GenericApiResponse<T> Success(List<string> errors, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessfully = true,
                IsSuccess = true
            };
        }

        public static GenericApiResponse<T> Success(bool isSuccess, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                IsSuccessfully = true
            };
        }

        public static GenericApiResponse<T> Success(bool isSuccess, T data, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                IsSuccess = isSuccess,
                StatusCode = statusCode,
                Data = data,
                IsSuccessfully = true
            };
        }

        public static GenericApiResponse<T> Success(T data, string message, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Data = data,
                Message = message,
                StatusCode = statusCode,
                IsSuccessfully = true,
                IsSuccess = true
            };
        }

        public static GenericApiResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }

        public static GenericApiResponse<T> Fail(string error, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }

        public static GenericApiResponse<T> Fail(string error)
        {
            return new GenericApiResponse<T>()
            {
                Errors = new List<string>() { error },
                IsSuccessfully = false,
                IsSuccess = false
            };
        }


        public static GenericApiResponse<T> Fail(int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }

        public static GenericApiResponse<T> Fail(T data, int statusCode)
        {
            return new GenericApiResponse<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }
    }
}

