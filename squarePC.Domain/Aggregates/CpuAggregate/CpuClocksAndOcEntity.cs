using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Частота и возможность разгона процессора
    /// </summary>
    public class CpuClocksAndOcEntity : Entity
    {
        
        public CpuClocksAndOcEntity(decimal baseClock, decimal turboClock, decimal baseClockECore,
            decimal turboClockECore, bool freeMultiplier)
        {
            _baseClock = baseClock;
            _turboClock = turboClock;
            _baseClockECore = baseClockECore;
            _turboClockECore = turboClockECore;
            _freeMultiplier = freeMultiplier;
        }
        
        /// <summary>
        /// Базовая частота процессора
        /// </summary>
        private decimal _baseClock;
        public string CpuBaseClock => _baseClock + "ГГц";

        /// <summary>
        /// Макзимальная частота
        /// </summary>
        private decimal _turboClock;
        public string CpuTurboClock => _turboClock + "ГГц";

        /// <summary>
        /// Базовая частота энергоэффективных ядер
        /// </summary>
        private decimal _baseClockECore;
        public string CpuBaseClockECore => _baseClockECore + "ГГц";

        /// <summary>
        /// Турбо частота энергоэффективных ядер
        /// </summary>
        private decimal _turboClockECore;
        public string CpuTurboClockECore => _turboClockECore + "ГГц";

        /// <summary>
        /// Свободный множитель
        /// </summary>
        private bool _freeMultiplier;
        public string CpuFreeMultiplier => _freeMultiplier ? "Да" : "Нет";
    }
}

