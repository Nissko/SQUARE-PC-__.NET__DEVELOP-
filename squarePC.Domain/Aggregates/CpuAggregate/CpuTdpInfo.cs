using System.ComponentModel.DataAnnotations;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Тепловые характеристики процессора
    /// </summary>
    public partial class CpuEntity
    {
        /// <summary>
        /// Тепловыделение
        /// </summary>
        [Range(1, 200)]
        private int _tdp;
        public string Tdp => _tdp.ToString();

        /// <summary>
        /// Базовое тепловыделение
        /// </summary>
        [Range(1, 200)]
        private int _baseTdp;
        public string BaseTdp => _baseTdp.ToString();

        /// <summary>
        /// Максимальная температура процессора
        /// </summary>
        [Range(1, 200)]
        private int _maxTempCpu;
        public string MaxTempCpu => _maxTempCpu.ToString();

        public async Task UpdateTdp(int? updateTdp, int? updateBaseTdp, int? updateMaxTempCpu)
        {
            _tdp = updateTdp ?? _tdp;
            _baseTdp = updateBaseTdp ?? _baseTdp;
            _maxTempCpu = updateMaxTempCpu ?? _maxTempCpu;

            await Task.CompletedTask;
        }
    }
}

