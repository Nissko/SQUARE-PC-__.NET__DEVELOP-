using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Процессор
    /// TODO: Предусмотреть добавления изображения
    /// TODO: Исправить баги, недочеты
    /// TODO: Переписать доменку(исправить недочеты привести к одному виду)
    /// </summary>
    public sealed partial class CpuEntity : Entity
    {
        public CpuEntity() { }


        public CpuEntity(decimal cpuPrice, int cpuCount, Guid familyCpuId, string model, Guid socketId,
            string codeManufacture, DateTime releaseDate, string warranty, int pCores, int eCores, string cacheL2,
            string cacheL3, int technoProcess, string coreName, bool virtualization, decimal baseClock,
            decimal turboClock, decimal baseClockECore, decimal turboClockECore, bool freeMultiplier, int tdp,
            int baseTdp, int maxTempCpu, Guid memoryTypeId, int maxValueMemory, int maxChannelMemory, int clockMemory,
            bool supportEcc, string pciExpressControllerVersion, int countLinesPciExpress, bool hasGpuCore,
            string cpuModelGraphCore, int cpuMaxClockGraphCore, int cpuGraphBlocks, int cpuShadingUnits)
        {
            //базовые данные
            _cpuPrice = cpuPrice > 0 ? cpuPrice : 0;
            _cpuCount = cpuCount > 0 ? cpuCount : 0;
            _inStock = _cpuCount > 0;

            //основные данные
            _familyCpuId = familyCpuId == Guid.Empty
                ? throw new ArgumentNullException(nameof(familyCpuId))
                : familyCpuId;
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _name = CpuNameFunction(_familyCpuId, _model);
            _socketId = socketId;
            _codeManufacture = codeManufacture;
            _releaseDate = releaseDate;
            _warranty = warranty;

            //ядро и архитектура
            _pCores = pCores;
            _eCores = eCores;
            _allCores = _pCores + _eCores;
            _cacheL2 = cacheL2;
            _cacheL3 = cacheL3;
            _technoProcess = technoProcess;
            _coreName = coreName;
            _virtualization = virtualization;
            _allThreads = CalculationAllTheadsFunction(_pCores, _eCores, _virtualization);

            //частота и возможность разгона
            _baseClock = baseClock;
            _turboClock = turboClock;
            _baseClockECore = baseClockECore;
            _turboClockECore = turboClockECore;
            _freeMultiplier = freeMultiplier;

            //тепловые характеристики
            _tdp = tdp;
            _baseTdp = baseTdp;
            _maxTempCpu = maxTempCpu;

            //параметры ОЗУ
            _memoryTypeId = memoryTypeId;
            _maxValueMemory = maxValueMemory;
            _maxChannelMemory = maxChannelMemory;
            _clockMemory = clockMemory;
            _supportECC = supportEcc;

            //шина и контроллер
            _pciExpressControllerVersion = pciExpressControllerVersion;
            _countLinesPciExpress = countLinesPciExpress;

            //графическое ядро
            _hasGpuCore = hasGpuCore;
            _cpuModelGraphCore = cpuModelGraphCore;
            _cpuMaxClockGraphCore = cpuMaxClockGraphCore;
            _cpuGraphBlocks = cpuGraphBlocks;
            _cpuShadingUnits = cpuShadingUnits;
        }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price => _cpuPrice;
        private decimal _cpuPrice;

        /// <summary>
        /// Наличие процессора
        /// </summary>
        public bool InStock => _inStock;
        private bool _inStock;

        /// <summary>
        /// Кол-во штук в наличии
        /// </summary>
        public int CpuCount => _cpuCount;
        private int _cpuCount;
        
        public ICollection<CpuImageEntity> CpuImages { get; private set; }

        #region Update

        /// <summary>
        /// Изменение цены и количества
        /// </summary>
        public async void UpdateCpuPriceAndCountAsync(CpuEntity cpuEntity)
        {
            await UpdatePrice(cpuEntity._cpuPrice);
            await UpdateCount(cpuEntity._cpuCount);
        }

        /// <summary>
        /// Изменение цены
        /// </summary>
        private async Task UpdatePrice(decimal? price)
        {
            _cpuPrice = price ?? _cpuPrice;
        }
        
        /// <summary>
        /// Изменение кол-ва
        /// </summary>
        private async Task UpdateCount(int? count)
        {
            _cpuCount = count ?? _cpuCount;
            _inStock = _cpuCount > 0;
            
            await Task.CompletedTask;
        }

        #endregion
    }
}