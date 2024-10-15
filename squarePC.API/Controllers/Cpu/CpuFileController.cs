using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using squarePC.Application.Application.Commands.Cpus.Images;

namespace squarePC.API.Controllers.Cpu
{
    [ApiController]
    [Route("[controller]")]
    public class CpuFileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CpuFileController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        [HttpPost("SetCpuImages")]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        public async Task<IActionResult> SetCpuImages([FromForm] Guid cpuId, [FromForm] IFormFileCollection files)
        {
            /*var command = new SetCpuImageCommand(cpuId, files);*/
            return Ok();
        }
    }
}