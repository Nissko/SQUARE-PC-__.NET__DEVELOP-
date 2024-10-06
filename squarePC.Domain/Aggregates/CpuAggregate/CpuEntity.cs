using squarePC.Domain.Aggregates.ConfigurationAggregate;
using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Процессор
    /// TODO: Предусмотреть добавления изображения
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
        public string CpuCount => _cpuCount + " шт.";
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
        
    }
}