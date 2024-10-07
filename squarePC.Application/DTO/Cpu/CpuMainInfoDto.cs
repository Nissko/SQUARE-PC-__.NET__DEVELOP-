namespace squarePC.Application.DTO.Cpu
{
    public class CpuMainInfoDto
    {
        /// <summary>
        /// ID семейства CPU
        /// </summary>
        public Guid FamilyCpuId { get; set; }

        /// <summary>
        /// Модель CPU
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// ID сокета
        /// </summary>
        public Guid SocketId { get; set; }

        /// <summary>
        /// Код производителя
        /// </summary>
        public string CodeManufacture { get; set; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Гарантия
        /// </summary>
        public string Warranty { get; set; }
    }
}