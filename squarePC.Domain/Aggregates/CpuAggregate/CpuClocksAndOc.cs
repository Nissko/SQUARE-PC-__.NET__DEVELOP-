namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Частота и возможность разгона процессора
    /// </summary>
    public sealed partial class CpuEntity
    {
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

        public async Task UpdateClocksAndOc(decimal? updateBaseClock, decimal? updateTurboClock,
            decimal? updateBaseClockECore, decimal? updateTurboClockECore, bool? updateFreeMultiplier)
        {
            _baseClock = updateBaseClock ?? _baseClock;
            _turboClock = updateTurboClock ?? _turboClock;
            _baseClockECore = updateBaseClockECore ?? _baseClockECore;
            _turboClockECore = updateTurboClockECore ?? _turboClockECore;
            _freeMultiplier = updateFreeMultiplier ?? _freeMultiplier;

            await Task.CompletedTask;
        }
    }
}

