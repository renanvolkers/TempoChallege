using Tempo.Common.Setup;

namespace Tempo.Knight.Dto.Requests.Knight
{
    /// <summary>
    /// Request for filter controller
    /// </summary>
    public class RequestFilterKnight : IRequest
    {
        public string? Name { get; set; } = "";
        public string? CharacterType { get; set; } = "";

        public RequestFilterKnight()
        {
            Name = string.Empty;
            CharacterType = string.Empty;
        }
    }
}
