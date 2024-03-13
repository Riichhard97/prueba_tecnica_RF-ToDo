using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Application.Features.Goals.Commands;
using PruebaTecnica.Core.Application.Features.Goals.Queries;
using PruebaTecnica.Shared.Dtos;

namespace PruebaTecnica.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IMediator _sender;
        public GoalController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpGet()]
        public async Task<List<GoalDto>> GetAll([FromQuery] ListAllGoalQuery query, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(query, cancellationToken);
            return (List<GoalDto>)result;
        }

        [HttpGet("{id}")]
        public async Task<GoalDto> GetById(int Id, CancellationToken cancellationToken)
        {
            var obj = new GetGoalByIdQuery();
            obj.Id = Id;
            var result = await _sender.Send(obj, cancellationToken);
            return (GoalDto)result;
        }

        [HttpPost()]
        public async Task<Unit> Add([FromBody] AddGoalCommand query, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<Unit> Update(int id, [FromBody] UpdateGoalCommand query, CancellationToken cancellationToken)
        {
            query.Id = id;
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<Unit> Delete(int id, CancellationToken cancellationToken)
        {
            DeleteGoalCommand query = new DeleteGoalCommand();
            query.Id = id;
            var result = await _sender.Send(query, cancellationToken);
            return result;
        }
    }
}
