using squarePC.Domain.Aggregates.Image;
using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Изображение процессоров
    /// </summary>
    public sealed class CpuImageEntity : Entity
    {
        public CpuImageEntity(CpuEntity cpu, ImageProductsEntity image)
        {
            _cpuId = cpu.Id;
            _imgId = image.Id;
        }
        
        /// <summary>
        /// Сущность процессоров
        /// </summary>
        public CpuEntity Cpu { get; private set; }
        private Guid _cpuId;

        /// <summary>
        /// Сущность изображений
        /// </summary>
        public ImageProductsEntity Image { get; private set; }
        private Guid _imgId;
    }
}