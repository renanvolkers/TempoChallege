using Tempo.Common.Setup.Error;

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of Interface response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseResponse<T>
    {
        public T? Data { get; set; }
        public IList<CustomValidationFailure> ErrorMessage { get; set; }
    }
}
