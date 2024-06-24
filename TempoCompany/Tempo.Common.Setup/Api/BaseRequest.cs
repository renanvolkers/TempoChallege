
using Tempo.Common.Setup.Error;

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of requests within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRequest<T>: IBaseRequest<T>
    {
        public T? Data { get; set; }
        public string Use { get; set; }
        public IList<CustomValidationFailure> ErrorMessage { get; set; }

        public BaseRequest(T data)
        {
            Data = data;
            Use = string.Empty;
            ErrorMessage = [];
        }
        public BaseRequest(IList<CustomValidationFailure> errorMessage)
        {
            Data = default;
            Use = "";
            ErrorMessage = errorMessage;
        }
        public BaseRequest()
        {
            Data = default;
            Use = "";
            ErrorMessage = [];
        }
    }
}
