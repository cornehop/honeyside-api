namespace Honeyside.Api.Data.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string CountryIsoCode { get; set; }
    }
}
