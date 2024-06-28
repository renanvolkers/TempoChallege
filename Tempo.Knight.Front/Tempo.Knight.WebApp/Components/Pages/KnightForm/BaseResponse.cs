
namespace Tempo.Knight.WebApp.Components.Pages.KnightForm
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T> where T : new()
    {
        public T Data { get; set; } 

        public BaseResponse(T data)
        {
            Data = data;
        }
        public BaseResponse()
        {
            Data = new T();
        }

    }
}
