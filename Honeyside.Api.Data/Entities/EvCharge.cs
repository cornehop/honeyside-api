namespace Honeyside.Api.Data.Entities
{
    /// <summary>
    /// Instance where an electric vehicle was charged
    /// </summary>
    public class EvCharge : BaseEntity
    {
        /// <summary>
        /// Identifier of the invoice this charge moment is tied to
        /// </summary>
        public Guid? InvoiceID { get; set; }
        /// <summary>
        /// Identifier of the EV charging station that was used
        /// </summary>
        public Guid EvChargingStationID { get; set; }
        /// <summary>
        /// Moment the charging started
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Moment the charging ended
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// Amount of KWh charged
        /// </summary>
        public decimal Kwh { get; set; }
        /// <summary>
        /// The cost price of this charge instance
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Invoice where this charge instance is tied to
        /// </summary>
        public virtual Invoice Invoice { get; set; }
        /// <summary>
        /// EV charging station that was used
        /// </summary>
        public virtual EvChargingStation EvChargingStation { get; set; }
    }
}
