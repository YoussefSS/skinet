using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SQLitePCL;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode); // ?? is a null coalescing operator, and it means if message is null, execute what's on the right of it
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return StatusCode switch // new switch statement in c# 8
            {
                400 => "Skinet - Bad request",
                401 => "Skinet - Not authorized",
                404 => "Skinet - Resource not found",
                500 => "Skinet - Internal server error",
                _ => null // default case
            };
        }
    }
}