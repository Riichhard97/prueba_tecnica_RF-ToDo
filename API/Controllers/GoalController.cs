using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Application.Features.Goals.Commands;
using PruebaTecnica.Core.Application.Features.Goals.Queries;
using PruebaTecnica.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PruebaTecnica.Shared.Dtos.Common;
using PruebaTecnica.Shared.RequestModels;

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

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PaginationResponseModel<GoalDto>>>> GetAll([FromQuery] ListAllGoalQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<PaginationResponseModel<GoalDto>>(true, "Metas obtenidas correctamente.", result));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<string>(false, $"Error al obtener todas las metas: {ex.Message}", null));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<GoalDto>>> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var obj = new GetGoalByIdQuery();
                obj.Id = id;
                var result = await _sender.Send(obj, cancellationToken);
                return Ok(new ApiResponse<GoalDto>(true, "Meta obtenida correctamente.", result));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<string>(false, $"Error al obtener la meta por ID: {ex.Message}", null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGoalCommand query, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Meta agregada correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al agregar la meta: {ex.Message}", Unit.Value));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGoalCommand query, CancellationToken cancellationToken)
        {
            try
            {
                query.Id = id;
                await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Meta actualizada correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al actualizar la meta: {ex.Message}", Unit.Value));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new DeleteGoalCommand { Id = id };
                await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Meta eliminada correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<string>(false, $"Error al eliminar la meta: {ex.Message}", null));
            }
        }
    }
}
