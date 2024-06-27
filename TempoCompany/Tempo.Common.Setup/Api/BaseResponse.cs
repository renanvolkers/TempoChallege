using Tempo.Common.Setup.Error;

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T> : IBaseResponse<T>  where T : class, new()
    {
        public T Data { get; set; }
        public IList<CustomValidationFailure> ErrorMessage { get; set; }

        public BaseResponse(T data)
        {
            Data = data;
            ErrorMessage = [];
        }
        public BaseResponse(IList<CustomValidationFailure> errorMessage)
        {
            Data = new T();
            ErrorMessage = errorMessage;
        }
        public BaseResponse()
        {
            Data = new T();
            ErrorMessage = [];
        }
    }
}
