

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> 
    {
        public required T Id { get; set; } 

    }
}
