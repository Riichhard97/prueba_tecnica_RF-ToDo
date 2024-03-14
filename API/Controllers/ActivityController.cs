using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Application.Features.Activities.Commands;
using PruebaTecnica.Core.Application.Features.Activities.Queries;
using PruebaTecnica.Shared.Dtos;
using PruebaTecnica.Shared.Dtos.Common;
using PruebaTecnica.Shared.RequestModels;

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

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ActivityDto>>>> GetAll([FromQuery] ListActivitiesQuerys query, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<List<ActivityDto>>(true, "Obtenidas lista de marcas correctamente.", result));

            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al obtener todas las actividades: {ex.Message}", Unit.Value));
            }
        }

        [HttpPost("GetAllByGoalId")]
        public async Task<ActionResult<ApiResponse<PaginationResponseModel<ActivityDto>>>> GetAllByGoalId([FromBody] ListActivitiesByGoalIdQuerys query, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<PaginationResponseModel<ActivityDto>>(true, "Obtenidas lista de marcas correctamente.", result));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al obtener las actividades por ID de meta: {ex.Message}", Unit.Value));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateActivityCommand query, CancellationToken cancellationToken)
        {
            try
            {
                query.Id = id;
                await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Actividad actualizada correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al actualizar la actividad: {ex.Message}", Unit.Value));
            }
        }

        [HttpPut("SetCompleteActivities")]
        public async Task<IActionResult> SetCompleteActivities([FromBody] SetCompleteActivitiesCommand query, CancellationToken cancellationToken)
        {
            try
            {
                await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Actividades marcadas como completadas correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al marcar las actividades como completadas: {ex.Message}", Unit.Value));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddActivityCommand query, CancellationToken cancellationToken)
        {
            try
            {
                await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Actividad agregada correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al agregar la actividad: {ex.Message}", Unit.Value));
            }
        }

        [HttpDelete("DeleteList")]
        public async Task<IActionResult> DeleteList([FromBody] DeleteActivitiesCommand query, CancellationToken cancellationToken)
        {
            try
            {
                await _sender.Send(query, cancellationToken);
                return Ok(new ApiResponse<Unit>(true, "Actividades eliminadas correctamente.", Unit.Value));
            }
            catch (Exception ex)
            {
                return StatusCode(200, new ApiResponse<Unit>(false, $"Error al eliminar las actividades: {ex.Message}", Unit.Value));
            }
        }
    }
}
