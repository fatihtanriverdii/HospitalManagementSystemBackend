using HospitalManagementSystem.Shared.DTOs;
using HospitalManagementSystem.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace HospitalManagementSystem.Infrastructure.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception caught by middleware");

                int statusCode;
                string message = ex.Message;

                if(ex is NotFoundException)
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                }
                else if(ex is DuplicateResourceException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Server side error.";
                }

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = statusCode;

                var errorResponse = new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    Message = message
                };

                var payload = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(payload);
            }
        }
    }
}
