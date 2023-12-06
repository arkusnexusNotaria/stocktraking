namespace Arkusnexus.StockTaking.ApplicationCore.Core.Entities
{
    public  class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? AddedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
