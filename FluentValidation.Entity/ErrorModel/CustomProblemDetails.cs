using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentValidation.Entity.ErrorModel
{
	public static class CustomErrorsDetails
	{
        public static IActionResult MakeValidationResponse(ActionContext context)
        {
            // Objeto que armazena as mensagens de erros
            var ErrorDetail = new ErrorDetail();

            // Percorrendo a lista de erros
            foreach (var keyModelStatePair in context.ModelState)
            {
                var errors = keyModelStatePair.Value.Errors;

                if (errors != null && errors.Count > 0)
                {
                    for (var i = 0; i < errors.Count; i++)
                    {
                        ErrorDetail.Mensagens.Add(GetErrorMessage(errors[i]));
                    }
                }
            }

            ErrorDetail.CodigoErro = context.HttpContext.TraceIdentifier;
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

