

using System.Net;
using System.Text.Json;

namespace Crud.Middleware;

public class ExceptionMiddleware
{
   
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _ilogger;

public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> ilogger)
    {
        _next = next;
        _ilogger = ilogger;
    }

    public async Task InvokeAsync(HttpContext concept)
    {
        try
        {
            await _next(concept);
        }catch(Exception ex)
        {
         _ilogger.LogError(ex, ex.Message);
         concept.Response.ContentType="application/json";
         concept.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

         var response = new {message = "internal Server Error", details = ex.Message };
         await concept.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    
}