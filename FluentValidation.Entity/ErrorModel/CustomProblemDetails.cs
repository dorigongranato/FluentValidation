using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentValidation.Entity.ErrorModel
{
	public static class CustomProblemDetails
	{

        //public static ErrorDetail ErrorDetail { get; set; } = new ErrorDetail();

        public static IActionResult MakeValidationResponse(ActionContext context)
        {

            var ErrorDetail = new ErrorDetail();

            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            };

            foreach (var keyModelStatePair in context.ModelState)
            {
                var errors = keyModelStatePair.Value.Errors;

                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        ErrorDetail.errors.Add(new Error()
                        {
                            message = errorMessage
                        });
                    }
                    else
                    {
                        var errorMessages = new string[errors.Count];
                        for (var i = 0; i < errors.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errors[i]);
                            ErrorDetail.errors.Add(new Error()
                            {
                                message = errorMessages[i]
                            });
                        }
                    }
                }
            }

            ErrorDetail.traceId = context.HttpContext.TraceIdentifier;
            ErrorDetail.timestamp = DateTime.Now;

            var result = new BadRequestObjectResult(ErrorDetail);

            result.ContentTypes.Add("application/problem+json");

            return result;
        }

        static string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
            "The input was not valid." :
            error.ErrorMessage;
        }
    }
}

