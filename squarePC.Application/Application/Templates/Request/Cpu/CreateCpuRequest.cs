namespace squarePC.Application.Application.Templates.Request.Cpu
{
    public record CreateCpuRequest()
    {
        /// <summary>
        /// Цена процессора
        /// </summary>
        public required decimal Price { get; init; }
        
        /// <summary>
        /// Количество в наличии
        /// </summary>
        public required int Count { get; init; }
        
        /// <summary>
        /// Идентификатор семейства процессора
        /// </summary>
        public required Guid FamilyCpuId { get; init; }
        
        /// <summary>
        /// Модель процессора
        /// </summary>
        public required string Model { get; init; }
        
        /// <summary>
        /// Идентификатор сокета
        /// </summary>
        public required Guid SocketId { get; init; }
        
        /// <summary>
        /// Код производителя
        /// </summary>
        public required string CodeManufacture { get; init; }
        
        /// <summary>
        /// Дата выпуска
        /// </summary>
        public required DateTime ReleaseDate { get; init; }
        
        /// <summary>
        /// Гарантия
        /// </summary>
        public required string Warranty { get; init; }
        
        /// <summary>
        /// Количество производительных ядер
        /// </summary>
        public required int PCores { get; init; }
        
        /// <summary>
        /// Количество энергоэффективных ядер
        /// </summary>
        public required int ECores { get; init; }
        
        /// <summary>
        /// Кэш L2
        /// </summary>
        public required string CacheL2 { get; init; }
        
        /// <summary>
        /// Кэш L3
        /// </summary>
        public required string CacheL3 { get; init; }
        
        /// <summary>
        /// Технологический процесс
        /// </summary>
        public required string TechnoProcess { get; init; }
        
        /// <summary>
        /// Название ядер
        /// </summary>
        public required string CoreName { get; init; }
        
        /// <summary>
        /// Поддержка виртуализации
        /// </summary>
        public required string Virtualization { get; init; }
        
        /// <summary>
        /// Базовая тактовая частота
        /// </summary>
        public required string BaseClock { get; init; }
        
        /// <summary>
        /// Турбо тактовая частота
        /// </summary>
        public required string TurboClock { get; init; }
        
        /// <summary>
        /// Базовая тактовая частота энергоэффективных ядер
        /// </summary>
        public required string BaseClockECore { get; init; }
        
        /// <summary>
        /// Турбо тактовая частота энергоэффективных ядер
        /// </summary>
        public required string TurboClockECore { get; init; }
        
        /// <summary>
        /// Разблокированный множитель
        /// </summary>
        public required string FreeMultiplier { get; init; }
        
        /// <summary>
        /// TDP процессора
        /// </summary>
        public required string Tdp { get; init; }
        
        /// <summary>
        /// Базовое значение TDP
        /// </summary>
        public required string BaseTdp { get; init; }
        
        /// <summary>
        /// Максимальная температура процессора
        /// </summary>
        public required string MaxTempCpu { get; init; }
        
        /// <summary>
        /// Идентификатор типа памяти
        /// </summary>
        public required Guid MemoryTypeId { get; init; }
        
        /// <summary>
        /// Максимальный объем памяти
        /// </summary>
        public required string MaxValueMemory { get; init; }
        
        /// <summary>
        /// Максимальное количество каналов памяти
        /// </summary>
        public required string MaxChannelMemory { get; init; }
        
        /// <summary>
        /// Частота памяти
        /// </summary>
        public required string ClockMemory { get; set; }
        
        /// <summary>
        /// Поддержка ECC памяти
        /// </summary>
        public required string SupportEcc { get; set; }
        
        /// <summary>
        /// Версия контроллера PCI Express
        /// </summary>
        public required string PciExpressControllerVersion { get; init; }
        
        /// <summary>
        /// Количество линий PCI Express
        /// </summary>
        public required int CountLinesPciExpress { get; init; }
        
        /// <summary>
        /// Наличие встроенного графического ядра
        /// </summary>
        public required string HasGpuCore { get; init; }
        
        /// <summary>
        /// Модель встроенного графического ядра
        /// </summary>
        public required string CpuModelGraphCore { get; init; }
        
        /// <summary>
        /// Максимальная тактовая частота графического ядра
        /// </summary>
        public required string CpuMaxClockGraphCore { get; init; }
        
        /// <summary>
        /// Количество графических блоков
        /// </summary>
        public required int CpuGraphBlocks { get; init; }
        
        /// <summary>
        /// Количество шейдерных блоков
        /// </summary>
        public required int CpuShadingUnits { get; init; }
    }
}