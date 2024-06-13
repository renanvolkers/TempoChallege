using Tempo.Common.Setup.Error;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Tempo.Common.Setup.Api
{
    public class TempoApiController : ControllerBase
    {
        /// <summary>
        /// provides helper methods for handling model validations and response formatting
        /// Inherits some features from the base
        /// Avoid repeating validations in the controllers, in the controller you only have to have service calls
        /// </summary>


        public TempoApiController()
        {
        }

        protected IActionResult HandleValidationFailure<T>(T model, AbstractValidator<T> validator)
        {
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { errors });
            }
            
            return Ok(model);
        }

        protected BaseRequest<T> ValidateRequest<T>(T model, AbstractValidator<T> validator) where T : IRequest
        {
            var validationResult = validator.Validate(model);


            var request = new BaseRequest<T>(model)
            {
                ErrorMessage = validationResult.Errors.ToCustomValidationFailure()
            };

            return request;
        }

        protected new IActionResult Response<TRequest>(IBaseResponse<TRequest> response)
        {
            if (response !=null && response.ErrorMessage.Any())
            {
                return BadRequest(response.ErrorMessage);
            }
            if(response != null)
            {
                return Ok(response.Data);
            }

            return Ok(response);
        }


    }


}
