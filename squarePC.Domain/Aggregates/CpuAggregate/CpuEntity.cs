using squarePC.Domain.Aggregates.ConfigurationAggregate;
using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Процессор
    /// </summary>
    public class CpuEntity : Entity
    {
        public CpuEntity() { }

        public CpuEntity(CpuMainInfoEntity cpuMainInfo, CpuCoreAndArchitectureEntity cpuCoreAndArchitecture,
            CpuClocksAndOcEntity cpuClocksAndOc, CpuTdpInfoEntity cpuTdp, CpuRamInfoEntity cpuRam,
            CpuBusAndControllersEntity cpuBusAndController, CpuGpuCoreInfoEntity cpuGpuCore)
        {
            CpuMainInfo = cpuMainInfo;
            CpuCoreAndArchitecture = cpuCoreAndArchitecture;
            CpuClocksAndOc = cpuClocksAndOc;
            CpuTdp = cpuTdp;
            CpuRam = cpuRam;
            CpuBusAndController = cpuBusAndController;
            CpuGpuCore = cpuGpuCore;
        }
        
        /// <summary>
        /// Общие параметры процессора
        /// </summary>
        public CpuMainInfoEntity CpuMainInfo { get; private set; }
        private Guid _cpuMainInfoId;
        
        public CpuCoreAndArchitectureEntity CpuCoreAndArchitecture { get; private set; }
        private Guid _cpuCoreAndArchitectureId;
        
        public CpuClocksAndOcEntity CpuClocksAndOc { get; private set; }
        private Guid _cpuClocksAndOcId;
        
        public CpuTdpInfoEntity CpuTdp { get; private set; }
        private Guid _cpuTdpId;
        
        public CpuRamInfoEntity CpuRam { get; private set; }
        private Guid _cpuRamId;
        
        public CpuBusAndControllersEntity CpuBusAndController { get; private set; }
        private Guid _cpuBusAndControllerId;
        
        public CpuGpuCoreInfoEntity CpuGpuCore { get; private set; }
        private Guid _cpuGpuCoreId;

        /// <summary>
        /// Добавление нового процессора
        /// </summary>
        public void CreateNewCpu(Guid cpuMainInfoId, Guid cpuCoreAndArchitectureId, Guid cpuClocksAndOcId,
            Guid cpuTdpId, Guid cpuRamId, Guid cpuBusAndControllerId, Guid cpuGpuCoreId)
        {
            _cpuMainInfoId = cpuMainInfoId;
            _cpuCoreAndArchitectureId = cpuCoreAndArchitectureId;
            _cpuClocksAndOcId = cpuClocksAndOcId;
            _cpuTdpId = cpuTdpId;
            _cpuRamId = cpuRamId;
            _cpuBusAndControllerId = cpuBusAndControllerId;
            _cpuGpuCoreId = cpuGpuCoreId;
        }
    }
}