using System.ComponentModel.DataAnnotations;

namespace Arkusnexus.StockTaking.ApplicationCore.Core.Entities
{
    public class DeviceItem : BaseEntity
    {
        [Required]
        public int DeviceId { get; set; }

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [Required]
        [MaxLength(150)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(250)]
        public string Model { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [MaxLength(1000)]
        public string Comments { get; set; }

        [Required]
        public int Status { get; set; }

    }
}