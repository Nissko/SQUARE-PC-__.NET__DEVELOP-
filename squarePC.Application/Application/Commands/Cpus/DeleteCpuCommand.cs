using MediatR;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class DeleteCpuCommand : IRequest<Unit>
    {
        public DeleteCpuCommand(Guid cpuId)
        {
            CpuId = cpuId;
        }

        public Guid CpuId { get; private set; }
    }
}