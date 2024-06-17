
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Tempo.Common.Setup.Error;


public class ReformatValidationProblemAttribute : ActionFilterAttribute
{
    /// <summary>
    /// Handle for take erro into application and custom mensagem for external consum
    /// </summary>
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is BadRequestObjectResult badRequestObjectResult)
            if (badRequestObjectResult.Value is ValidationProblemDetails)
            {
                var result = (ValidationProblemDetails)badRequestObjectResult.Value;
                context.Result =new UnprocessableEntityObjectResult(
                     result.Errors.Values.ToDictionaryValidationFailure()
                     );
            }

        base.OnResultExecuting(context);
    }
}