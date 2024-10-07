using System.ComponentModel.DataAnnotations;
using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Тепловые характеристики процессора
    /// </summary>
    public class CpuTdpInfoEntity : Entity
    {
        public CpuTdpInfoEntity() { }

        public CpuTdpInfoEntity(int tdp, int baseTdp, int maxTempCpu)
        {
            _TDP = tdp;
            _baseTDP = baseTdp;
            _maxTempCPU = maxTempCpu;
        }

        /// <summary>
        /// Тепловыделение
        /// </summary>
        [Range(0, 9999)]
        private int _TDP;
        public string TDP => _TDP.ToString();

        /// <summary>
        /// Базовое тепловыделение
        /// </summary>
        [Range(0, 9999)]
        private int _baseTDP;
        public string BaseTDP => _baseTDP.ToString();

        /// <summary>
        /// Максимальная температура процессора
        /// </summary>
        [Range(0, 9999)]
        private int _maxTempCPU;
        public string MaxTempCPU => _maxTempCPU.ToString();

        public async Task<CpuTdpInfoEntity> UpdateTdp(int? updateTdp, int? updateBaseTdp, int? updateMaxTempCpu)
        {
            _TDP = updateTdp ?? _TDP;
            _baseTDP = updateBaseTdp ?? _baseTDP;
            _maxTempCPU = updateMaxTempCpu ?? _maxTempCPU;

            return this;
        }
    }
}

