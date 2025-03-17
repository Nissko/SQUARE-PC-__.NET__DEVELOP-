using MediatR;
using squarePC.Application.DTO.Cpu;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class ReadCpuFromIdCommand : IRequest<CpuDto>
    {
        public ReadCpuFromIdCommand(Guid cpuId)
        {
            CpuId = cpuId;
        }

        public Guid CpuId { get; private set; }
    }
}