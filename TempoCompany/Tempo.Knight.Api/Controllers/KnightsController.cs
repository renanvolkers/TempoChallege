using Tempo.Knight.Application.Domain.Knights;
using Tempo.Knight.Application.Validations.Knight;
using Tempo.Knight.Dto.Requests.Knight;
using Microsoft.AspNetCore.Mvc;
using Tempo.Common.Setup.Api;

namespace Tempo.Knight.Api.Controllers
{
    [ApiController]
    [Route("/knights")]
    public class KnightsController : TempoApiController
    {
        private readonly IKnightService _knightService;


        public KnightsController(IKnightService knightService) : base()
        {
            _knightService = knightService;
        }

        /// <summary>
        /// Displays the list of all knights. If the parameter filter does not pass.
        /// Displays a list containing only warriors who have become heroes.. 
        /// </summary>
        /// <param name="filter">Displays a list containing only warriors who have become heroes. </param>
        /// <returns>
        [HttpGet]
        public async Task<IActionResult> FilterKnightsAsync([FromQuery]  string  filter="" )
        {
            return Response(await _knightService.GetFilterAsync(filter));
        }
        /// <summary>
        /// Creates knight request
        /// </summary>
        /// <param name="request">The knight request to create</param>
        /// <returns>
        [HttpPost]
        public async Task<IActionResult> PostKnightsAsync(RequestKnight request)
        {
            var baseRequest = ValidateRequest(request, new AddKnightValidator());
            return Response(await _knightService.AddKnightAsync(baseRequest));
        }
        /// <summary>
        /// Get  ID unique knight
        /// </summary>
        /// <param name="id">The Id  Identification to return</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdKnightsAsync(Guid id)
        {
            return Response(await _knightService.GetByIdAsync(id));
        }
        /// <summary>
        /// Delete knight 
        /// </summary>
        /// <param name="id">Remove a warrior. This warrior must enter the Hall of Heroes.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnightsAsync(Guid id)
        {
            var baseRequest = new BaseRequest<RequestDeleteKnight> { Data= new RequestDeleteKnight()} ;

            return Response(await _knightService.UpdateAsync(baseRequest, x => x.Id == id));
        }
        /// <summary>
        /// Allows you to change the nickname. 
        /// </summary>
        /// <param name="requestUpdate">The knight request to  Update.</param>
        /// <param name="id">The Id to look for Knight.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnightsAsync(Guid id, [FromBody] RequestUpdateKnight requestUpdate)
        {
            var baseRequest = ValidateRequest(requestUpdate, new UpdateKnightValidator());

            return Response(await _knightService.UpdateAsync(baseRequest,x=>x.Id==id));
        }
    }
}
