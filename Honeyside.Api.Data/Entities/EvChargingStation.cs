using System.ComponentModel.DataAnnotations;

namespace Honeyside.Api.Data.Entities
{
    /// <summary>
    /// Charging station for electric vehicles
    /// </summary>
    public class EvChargingStation : BaseEntity
    {
        /// <summary>
        /// Unique identifier used by an external application
        /// </summary>
        [StringLength(25)]
        public string? ExternalIdentifier { get; set; }
        /// <summary>
        /// Unique identifier of the Address
        /// </summary>
        public Guid AddressID { get; set; }

        /// <summary>
        /// The address this charging station is located
        /// </summary>
        public virtual Address Address { get; set; }
    }
}
