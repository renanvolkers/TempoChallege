

namespace Tempo.Common.Setup.Api
{
    /// <summary>
    /// pattern of response within the project
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> where T :new()
    {
        public T Id { get; set; } = new();

    }
}
