using squarePC.Domain.Common;
using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Общие параметры процессора
    /// </summary>
    public class CpuMainInfoEntity : Entity
    {
        public CpuMainInfoEntity(Guid familyCpuId, string model, Guid socketId, string codeManufacture,
            DateTime releaseDate, string warranty, Guid cpuId)
        {
            _familyCpuId = familyCpuId;
            _model = model;
            _socketId = socketId;
            _codeManufacture = codeManufacture;
            _releaseDate = releaseDate;
            _warranty = warranty;
            CpuId = cpuId;
        }

        /// <summary>
        /// Внешний ключ процессора
        /// </summary>
        public Guid CpuId { get; private set; }
        
        /// <summary>
        /// Название процессора
        /// </summary>
        private string _name;
        public string CpuName => CpuNameFunction(_familyCpuId, _model);

        /// <summary>
        /// Семейство процессора
        /// </summary>
        private Guid _familyCpuId;
        public CpuFamilyEnum CpuFamily { get; private set; }

        /// <summary>
        /// Модель
        /// </summary>
        private string _model;
        public string CpuModel => _model;

        /// <summary>
        /// Сокет
        /// </summary>
        private Guid _socketId;
        public CpuSocketEnum CpuSocket { get; private set; }

        /// <summary>
        /// Код производителя
        /// </summary>
        private string _codeManufacture;
        private string CpuManufacture => _codeManufacture;

        /// <summary>
        /// Дата выхода
        /// </summary>
        private DateTime _releaseDate;
        public DateTime CpuReleaseDate => _releaseDate;

        /// <summary>
        /// Гарантия
        /// </summary>
        private string _warranty;
        public string CpuWarranty => _warranty;

        /// <summary>
        /// Формирование названия процессора
        /// </summary>
        /// <param name="familyCpu"></param>
        /// <param name="modelCpu"></param>
        private string CpuNameFunction(Guid familyCpuId, string modelCpu)
        {
            var familyCpu = CpuFamily.Name;

            if (familyCpu.Length == 0 || modelCpu.Length == 0)
            {
                /*TODO: переписать исключение*/
                throw new Exception("Exception");
            }

            _name = $"Процессор {familyCpu} {modelCpu}";

            return _name;
        }
    }
}