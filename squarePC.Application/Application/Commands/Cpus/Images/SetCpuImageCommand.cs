using MediatR;

namespace squarePC.Application.Application.Commands.Cpus.Images
{
    public class SetCpuImageCommand : IRequest
    {
        public SetCpuImageCommand(Guid cpuId, List<byte[]> imageId)
        {
            CpuId = cpuId;
            ImageId = imageId;
        }

        public Guid CpuId { get; private set; }
        public List<byte[]> ImageId { get; private set; }
    }
}