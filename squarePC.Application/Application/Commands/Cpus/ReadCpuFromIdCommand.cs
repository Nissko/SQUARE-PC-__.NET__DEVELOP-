using MediatR;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class ReadCpuFromIdCommand : IRequest<CpuEntity>
    {
        public ReadCpuFromIdCommand(Guid cpuId)
        {
            CpuId = cpuId;
        }

        public Guid CpuId { get; set; }
    }
}