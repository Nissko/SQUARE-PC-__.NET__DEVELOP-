using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using squarePC.Application.Application.Commands.Cpus;
using squarePC.Application.Application.Queries.Cpus;
using squarePC.Application.Application.Templates.CpusRequest;

namespace squarePC.API.Controllers
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

            return new OkObjectResult(result);
        }

        #region CRUD

        /// <summary>
        /// Добавление нового процессора
        /// </summary>
        [HttpPost("CreateCpu")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<Unit> CreateCpu([FromBody] CreateCpuRequest request)
        {
            var command = new CreateNewCpuCommand(request);
            var result = await _mediator.Send(command);
            
            return result;
        }

        #endregion

    }
}