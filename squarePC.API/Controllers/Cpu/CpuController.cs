using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using squarePC.Application.Application.Commands.Cpus;
using squarePC.Application.Application.Queries.Cpus;
using squarePC.Application.Application.Templates.Request.Cpu;

namespace squarePC.API.Controllers.Cpu
{
    [ApiController]
    [Route("[controller]")]
    public class CpuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CpuController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Получение всех процессоров
        /// </summary>
        [HttpGet("GetAllCpus")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllCpus([FromQuery] GetAllCpusQuery request)
        {
            var result = await _mediator.Send(request);

            return new JsonResult(result);
        }

        #region CRUD

        /// <summary>
        /// Добавление нового процессора
        /// </summary>
        [HttpPost("CreateCpu")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateCpu([FromBody] CreateCpuRequest request)
        {
            var command = new CreateNewCpuCommand(request);
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        /// <summary>
        /// Поиск процессора по ID
        /// </summary>
        [HttpGet("ReadCpuFromId")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> ReadCpuFromId([FromQuery] Guid cpuId)
        {
            var command = new ReadCpuFromIdCommand(cpuId);
            
            var result = await _mediator.Send(command);
            
            return new JsonResult(result);
        }

        /// <summary>
        /// Изменения процессора по Id
        /// </summary>
        [HttpPost("UpdateCpuFromId")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateCpu([FromBody] UpdateCpuRequest request)
        {
            var command = new UpdateCpuCommand(request);

            var result = await _mediator.Send(command);
            
            return new JsonResult(result);
        }

        /// <summary>
        /// Удаление процессора по Id
        /// </summary>
        [HttpGet("DeleteCpuFromId")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteCpu([FromQuery] Guid cpuId)
        {
            var command = new DeleteCpuCommand(cpuId);

            var result = await _mediator.Send(command);

            return new JsonResult(result);
        }

        #endregion
    }
}