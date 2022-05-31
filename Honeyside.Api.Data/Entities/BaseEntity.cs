using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Honeyside.Api.Data.Entities
{
    /// <summary>
    /// Base class for the entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Unique identifier of the entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
    }
}
