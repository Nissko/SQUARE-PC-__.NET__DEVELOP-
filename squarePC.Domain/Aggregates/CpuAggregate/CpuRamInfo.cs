using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Параметры ОЗУ процессора
    /// </summary>
    public partial class CpuEntity
    {
        /// <summary>
        /// Тип поддерживаемой памяти
        /// </summary>
        private Guid _memoryTypeId;
        public CpuMemoryTypeEnum MemoryType { get; private set; }

        /// <summary>
        /// Максимально поддерживаемый объем памяти
        /// </summary>
        private int _maxValueMemory;
        public string MaxValueMemory => _maxValueMemory.ToString();

        /// <summary>
        /// Количество каналов
        /// </summary>
        private int _maxChannelMemory;
        public string MaxChannelMemory => _maxChannelMemory.ToString();

        /// <summary>
        /// Частота оперативной памяти
        /// </summary>
        private int _clockMemory;
        public string ClockMemory => _clockMemory.ToString();

        /// <summary>
        /// Поддержка режима ECC
        /// </summary>
        private bool _supportECC;
        public string SupportECC => _supportECC ? "Да" : "Нет";

        public async Task UpdateRam(Guid memoryTypeId, int? maxValueMemory, int? maxChannelMemory,
            int? clockMemory, bool? supportEcc)
        {
            _memoryTypeId = memoryTypeId;
            _maxValueMemory = maxValueMemory?? _maxValueMemory;
            _maxChannelMemory = maxChannelMemory?? _maxChannelMemory;
            _clockMemory = clockMemory?? _clockMemory;
            _supportECC = supportEcc?? _supportECC;

            await Task.CompletedTask;
        }
    }
}