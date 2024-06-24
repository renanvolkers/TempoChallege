using System.Text.Json.Serialization;
using Tempo.Common.Setup;

namespace Tempo.Knight.Dto.Requests.Knight
{

    /// <summary>
    /// Request for training controller
    /// </summary>
    public class RequestTrainingKnight : IRequest
    {
        public float CombatTraining { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedAt { get; set; }


    }
}
