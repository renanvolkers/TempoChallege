using Tempo.Common.Setup;

namespace Tempo.Knight.Dto.Requests.Knight
{

    /// <summary>
    /// Request for update controller
    /// </summary>
    public class RequestUpdateKnight : IRequest
    {
        public string Nickname { get; set; } = "";

    }
}
