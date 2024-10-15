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
            DateTime releaseDate, string warranty)
        {
            _familyCpuId = familyCpuId;
            _model = model;
            _socketId = socketId;
            _codeManufacture = codeManufacture;
            _releaseDate = releaseDate;
            _warranty = warranty;
            _name = CpuNameFunction(_familyCpuId, _model);
        }
        
        /// <summary>
        /// Название процессора
        /// </summary>
        private string _name;
        public string CpuName => _name;

        /// <summary>
        /// Семейство процессора
        /// </summary>
        private Guid _familyCpuId;
        public virtual CpuFamilyEnum CpuFamily { get; private set; }

        /// <summary>
        /// Модель
        /// </summary>
        private string _model;
        public string CpuModel => _model;

        /// <summary>
        /// Сокет
        /// </summary>
        private Guid _socketId;
        public virtual CpuSocketEnum CpuSocket { get; private set; }

        /// <summary>
        /// Код производителя
        /// </summary>
        private string _codeManufacture;
        public string CpuManufacture => _codeManufacture;

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
        private string CpuNameFunction(Guid familyCpuId, string modelCpu)
        {
            var familyCpu = CpuFamilyEnum.From(familyCpuId);

            if (familyCpu.Length == 0 || modelCpu.Length == 0)
            {
                /*TODO: переписать исключение*/
                throw new Exception("Exception");
            }

            _name = $"Процессор {familyCpu} {modelCpu}";

            return _name;
        }

        public async Task<CpuMainInfoEntity> UpdateMainInfo(Guid? familyCpuId, string modelCpu, Guid? socketId,
            string codeManufacture, DateTime? releaseDate, string warranty)

        {
            _familyCpuId = familyCpuId ?? _familyCpuId;
            _model = modelCpu ?? _model;
            _socketId = socketId ?? _socketId;
            _codeManufacture = codeManufacture ?? _codeManufacture;
            _releaseDate = releaseDate ?? _releaseDate;
            _warranty = warranty ?? _warranty;
            _name = CpuNameFunction(_familyCpuId, _model);

            return this;
        }
    }
}