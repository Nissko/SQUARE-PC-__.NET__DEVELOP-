using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Exceptions.CpusApplicationException;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class DeleteCpuCommandHandler : IRequestHandler<DeleteCpuCommand, Unit>
    {
        private readonly ICpuRepository _repository;

        public DeleteCpuCommandHandler(ICpuRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Unit> Handle(DeleteCpuCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCpuIdAsync(request.CpuId, cancellationToken);

            return Unit.Value;
        }
    }
}