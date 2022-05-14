namespace Honeyside.Api.Data.Entities
{
    public class EvCharge : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Guid EvChargeStationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Kwh { get; set; }
        public decimal Price { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual EvChargeStation EvChargeStation { get; set; }
    }
}
