namespace squarePC.Application.Application.Models.Cpus.Create
{
    public class CpuMainInfoItem
    {
        public Guid FamilyCpuId { get; init; }
        public string Model { get; init; }
        public Guid SocketId { get; init; }
        public string CodeManufacture { get; init; }
        public DateTime ReleaseDate { get; init; }
        public string Warranty { get; init; }
    }
}