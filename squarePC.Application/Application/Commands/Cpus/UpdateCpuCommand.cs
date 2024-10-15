using MediatR;
using squarePC.Application.Application.Templates.Request.Cpu;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class UpdateCpuCommand : IRequest<Unit>
    {
        public UpdateCpuCommand(UpdateCpuRequest updateCpu)
        {
            UpdateCpu = updateCpu;
        }

        /// <summary>
        /// Запрос изменяемого процессора
        /// </summary>
        public UpdateCpuRequest UpdateCpu { get; private set; }
    }
}