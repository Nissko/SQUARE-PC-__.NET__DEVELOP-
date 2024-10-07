using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Процессор
    /// TODO: Предусмотреть добавления изображения
    /// TODO: Исправить баги, недочеты
    /// </summary>
    public class CpuEntity : Entity
    {
        public CpuEntity() { }

        public CpuEntity(decimal cpuPrice, int cpuCount, CpuMainInfoEntity cpuMainInfo,
            CpuCoreAndArchitectureEntity cpuCoreAndArchitecture,
            CpuClocksAndOcEntity cpuClocksAndOc, CpuTdpInfoEntity cpuTdp, CpuRamInfoEntity cpuRam,
            CpuBusAndControllersEntity cpuBusAndController, CpuGpuCoreInfoEntity cpuGpuCore)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(cpuCount);

            _cpuPrice = cpuPrice;
            _cpuCount = cpuCount;
            CpuMainInfo = cpuMainInfo;
            CpuCoreAndArchitecture = cpuCoreAndArchitecture;
            CpuClocksAndOc = cpuClocksAndOc;
            CpuTdp = cpuTdp;
            CpuRam = cpuRam;
            CpuBusAndController = cpuBusAndController;
            CpuGpuCore = cpuGpuCore;
            _inStock = _cpuCount > 0 ? true : false;
        }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price => _cpuPrice;
        private decimal _cpuPrice;

        /// <summary>
        /// Наличие процессора
        /// </summary>
        public string InStock => _inStock ? "Да" : "Нет";
        private bool _inStock;

        /// <summary>
        /// Кол-во штук в наличии
        /// </summary>
        public int CpuCount => _cpuCount;
        private int _cpuCount;
        
        /// <summary>
        /// Общие параметры
        /// </summary>
        public CpuMainInfoEntity CpuMainInfo { get; private set; }
        private Guid _cpuMainInfoId;
        
        /// <summary>
        /// Ядро и архитектура
        /// </summary>
        public CpuCoreAndArchitectureEntity CpuCoreAndArchitecture { get; private set; }
        private Guid _cpuCoreAndArchitectureId;
        
        /// <summary>
        /// Частота и возможность разгона
        /// </summary>
        public CpuClocksAndOcEntity CpuClocksAndOc { get; private set; }
        private Guid _cpuClocksAndOcId;
        
        /// <summary>
        /// Тепловые характеристики
        /// </summary>
        public CpuTdpInfoEntity CpuTdp { get; private set; }
        private Guid _cpuTdpId;
        
        /// <summary>
        /// Параметры ОЗУ
        /// </summary>
        public CpuRamInfoEntity CpuRam { get; private set; }
        private Guid _cpuRamId;
        
        /// <summary>
        /// Шина и контроллер
        /// </summary>
        public CpuBusAndControllersEntity CpuBusAndController { get; private set; }
        private Guid _cpuBusAndControllerId;
        
        /// <summary>
        /// Графическое ядро
        /// </summary>
        public CpuGpuCoreInfoEntity CpuGpuCore { get; private set; }
        private Guid _cpuGpuCoreId;

        public async Task<CpuEntity> UpdateCpu(Guid cpuId, decimal? updatePrice, int? updateCount, Guid? familyCpuId,
            string modelCpu, Guid? socketId, string codeManufacture, DateTime? releaseDate, string warranty,
            int? updatePCores, int? updateECores, string updateCacheL2, string updateCacheL3, int? updateTechnoProcess,
            string updateCoreName, bool? updateVirtualization, decimal? updateBaseClock, decimal? updateTurboClock,
            decimal? updateBaseClockECore, decimal? updateTurboClockECore, bool? updateFreeMultiplier, int? updateTdp,
            int? updateBaseTdp, int? updateMaxTempCpu, Guid memoryTypeId, int? maxValueMemory, int? maxChannelMemory,
            int? clockMemory, bool? supportEcc, string pciExpressControllerVersion, int countLinesPciExpress,
            bool? hasGpuCore, string cpuModelGraphCore, int? cpuMaxClockGraphCore, int? cpuGraphBlocks,
            int? cpuShadingUnits)

        {
            if (!Id.Equals(cpuId))
            {
                /*TODO: Переделать исключение*/
                throw new ArgumentException("Invalid");
            }

            _cpuPrice = updatePrice ?? _cpuPrice;
            _cpuCount = updateCount ?? _cpuCount;
            _inStock = _cpuCount > 0 ? true : false;

            CpuMainInfo = await CpuMainInfo.UpdateMainInfo(familyCpuId, modelCpu, socketId, codeManufacture,
                releaseDate, warranty);
            CpuCoreAndArchitecture = await CpuCoreAndArchitecture.UpdateCoreAndArchitecture(updatePCores, updateECores,
                updateCacheL2, updateCacheL3, updateTechnoProcess, updateCoreName, updateVirtualization);
            CpuClocksAndOc = await CpuClocksAndOc.UpdateClocksAndOc(updateBaseClock, updateTurboClock,
                updateBaseClockECore, updateTurboClockECore, updateFreeMultiplier);
            CpuTdp = await CpuTdp.UpdateTdp(updateTdp, updateBaseTdp, updateMaxTempCpu);
            CpuRam = await CpuRam.UpdateRam(memoryTypeId, maxValueMemory, maxChannelMemory, clockMemory, supportEcc);
            CpuBusAndController =
                await CpuBusAndController.UpdateBusAndController(pciExpressControllerVersion, countLinesPciExpress);
            CpuGpuCore = await CpuGpuCore.UpdateGpuCore(hasGpuCore, cpuModelGraphCore, cpuMaxClockGraphCore, cpuGraphBlocks, cpuShadingUnits);

            return this;
        }

    }
}