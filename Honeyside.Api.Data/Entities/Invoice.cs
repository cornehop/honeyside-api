namespace Honeyside.Api.Data.Entities
{
    public class Invoice : BaseEntity
    {
        public string ExternalIdentifier { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
