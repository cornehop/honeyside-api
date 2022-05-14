namespace Honeyside.Api.Data.Entities
{
    public class EvChargeStation : BaseEntity
    {
        public string ExternalIdentifier { get; set; }
        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
