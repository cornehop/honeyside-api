using System.ComponentModel.DataAnnotations;

namespace Honeyside.Api.Data.Entities
{
    /// <summary>
    /// Address entity
    /// </summary>
    public class Address : BaseEntity
    {
        /// <summary>
        /// The street, max-length is 100
        /// </summary>
        [StringLength(100)]
        public string Street { get; set; }
        /// <summary>
        /// The number
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// The city, max-length is 50
        /// </summary>
        [StringLength(50)]
        public string City { get; set; }
        /// <summary>
        /// The ISO code of the country using the Alpha-3 code standard (e.g. NLD for The Netherlands)
        /// </summary>
        [StringLength(3)]
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// Collection with EV charge stations that are located at this address
        /// </summary>
        public virtual ICollection<EvChargingStation> EvChargeStations { get; set; }
    }
}
