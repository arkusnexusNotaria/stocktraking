using System.ComponentModel.DataAnnotations;

namespace Arkusnexus.StockTaking.ApplicationCore.Core.Entities
{
    public class Device : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

    }
}