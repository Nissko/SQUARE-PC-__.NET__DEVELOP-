using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Графическое ядро процессора
    /// </summary>
    public class CpuGpuCoreInfoEntity : Entity
    {
        public CpuGpuCoreInfoEntity(bool hasGpuCore, string cpuModelGraphCore, int cpuMaxClockGraphCore,
            int cpuGraphBlocks, int cpuShadingUnits)
        {
            _hasGpuCore = hasGpuCore;
            _cpuModelGraphCore = cpuModelGraphCore;
            _cpuMaxClockGraphCore = cpuMaxClockGraphCore;
            _cpuGraphBlocks = cpuGraphBlocks;
            _cpuShadingUnits = cpuShadingUnits;
        }

        /// <summary>
        /// Есть ли графическое ядро (Да/Нет)
        /// </summary>
        private bool _hasGpuCore;
        public string CpuHasGpuCore => _hasGpuCore ? "Да" : "Нет";

        /// <summary>
        /// Модель графического процессора
        /// </summary>
        private string _cpuModelGraphCore;
        public string CpuModelGraphCore => _cpuModelGraphCore;
        
        /// <summary>
        /// Максимальная частота графического ядра
        /// </summary>
        private int _cpuMaxClockGraphCore;
        public string CpuMaxClockGraphCore => _cpuMaxClockGraphCore + "ГГц";

        /// <summary>
        /// Испольнительные блоки
        /// </summary>
        private int _cpuGraphBlocks;
        public int CpuGraphBlocks => _cpuGraphBlocks;

        /// <summary>
        /// Потоковые процессоры
        /// </summary>
        private int _cpuShadingUnits;
        public int CpuShadingUnits => _cpuShadingUnits;
    }
}