using Tempo.Common.Setup.Error;

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T> : IBaseResponse<T>  
    {
        public T? Data { get; set; } 
        public IList<CustomValidationFailure> ErrorMessage { get; set; }

        public BaseResponse(T data)
        {
            Data = data;
            ErrorMessage = [];
        }
        public BaseResponse(IList<CustomValidationFailure> errorMessage)
        {
            Data = default;
            ErrorMessage = errorMessage;
        }
        public BaseResponse()
        {
            Data = default;
            ErrorMessage = [];
        }
    }
}
