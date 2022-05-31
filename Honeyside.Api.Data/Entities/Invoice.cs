using System.ComponentModel.DataAnnotations;

namespace Honeyside.Api.Data.Entities
{
    /// <summary>
    /// Invoice entity
    /// </summary>
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// Unique identifier used by the external party
        /// </summary>
        [StringLength(25)]
        public string? ExternalIdentifier { get; set; }
        /// <summary>
        /// Invoice date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Amount of the invoice after taxes
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Collection with EV charge moments that are part of this invoice
        /// </summary>
        public virtual ICollection<EvCharge> EvCharges { get; set; }
    }
}
