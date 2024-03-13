using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Application.Features.Activities.Commands;
using PruebaTecnica.Core.Application.Features.Activities.Queries;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ISender _sender;
        public ActivityController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet()]
        public async Task<List<ActivityDto>> GetAll([FromQuery] ListActivitiesQuerys query, CancellationToken cancellationToken)
        {

            var result = await _sender.Send(query, cancellationToken);
            return result;
        }


        [HttpPut("{id}")]
        public async Task<Unit> Update(int id, [FromBody] UpdateActivityCommand query, CancellationToken cancellationToken)
        {
            query.Id = id;
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }

        [HttpPut("SetCompleteActivities")]
        public async Task<Unit> SetCompleteActivities([FromBody] SetCompleteActivitiesCommand query,CancellationToken cancellationToken){
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }

        [HttpPost()]
        public async Task<Unit> Add([FromBody] AddActivityCommand query, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }

        [HttpDelete("DeleteList")]
        public async Task<Unit> DeleteList([FromBody] DeleteActivitiesCommand query, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }
    }
}
