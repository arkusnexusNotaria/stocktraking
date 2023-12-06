namespace Arkusnexus.StockTaking.API.Dtos
{
    public class DeviceItemDto
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }

        public string SerialNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Notes { get; set; }

        public string Comments { get; set; }

        public int Status { get; set; }

   }
}