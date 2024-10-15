using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;
using squarePC.Application.Exceptions.CpusApplicationException;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class ReadCpuFromIdCommandHandler : IRequestHandler<ReadCpuFromIdCommand, CpuDto>
    {
        private readonly ICpuRepository _cpuRepository;
        private readonly ICustomMapper _mapper;

        public ReadCpuFromIdCommandHandler(ICpuRepository cpuRepository, ICustomMapper mapper)
        {
            _cpuRepository = cpuRepository?? throw new ArgumentNullException(nameof(cpuRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CpuDto> Handle(ReadCpuFromIdCommand request, CancellationToken cancellationToken)
        {
            var cpuFind = await _cpuRepository.GetByIdAsync(request.CpuId);

            if (cpuFind == null) throw new CpuNullException(request.CpuId);
            
            return _mapper.CpuMapperProfile.GetCpuDto(cpuFind);
        }
    }
}