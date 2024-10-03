using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Тепловые характеристики процессора
    /// </summary>
    public class CpuTdpInfoEntity : Entity
    {
        public CpuTdpInfoEntity() { }
        public CpuTdpInfoEntity(int tdp, int baseTdp, int maxTempCpu, Guid cpuId)
        {
            _TDP = tdp;
            _baseTDP = baseTdp;
            _maxTempCPU = maxTempCpu;
            CpuId = cpuId;
        }

        /// <summary>
        /// Внешний ключ процессора
        /// </summary>
        public Guid CpuId { get; private set; }
        
        /// <summary>
        /// Тепловыделение
        /// </summary>
        private int _TDP;
        public string TDP => _TDP.ToString();

        /// <summary>
        /// Базовое тепловыделение
        /// </summary>
        private int _baseTDP;
        public string BaseTDP => _baseTDP.ToString();

        /// <summary>
        /// Максимальная температура процессора
        /// </summary>
        private int _maxTempCPU;
        public string MaxTempCPU => _maxTempCPU.ToString();
    }
}

