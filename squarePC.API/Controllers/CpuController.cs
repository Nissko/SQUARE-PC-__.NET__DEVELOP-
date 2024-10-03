using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using squarePC.Application.Application.Queries.Cpus;

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

        [HttpGet("GetAllCpus")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllCpus([FromQuery] GetAllCpusQuery request)
        {
            var result = await _mediator.Send(request);

            return new OkObjectResult(result);
        }
    }
}