using squarePC.Domain.Aggregates.Image;
using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Изображение процессоров
    /// </summary>
    public class CpuImageEntity : Entity
    {
        public CpuImageEntity(Guid cpuId, Guid imgId)
        {
            _cpuId = cpuId;
            _imgId = imgId;
        }
        
        /// <summary>
        /// Сущность процессоров
        /// </summary>
        public virtual CpuEntity Cpu { get; private set; }
        private Guid _cpuId;

        /// <summary>
        /// Сущность изображений
        /// </summary>
        public virtual ImageProductsEntity Image { get; private set; }
        private Guid _imgId;
    }
}