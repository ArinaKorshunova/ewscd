using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class CuratorPatient : BaseEntity
    {
        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        #region Curator

        public virtual Curator Curator { get; set; }

        [Required]
        [ForeignKey("Curator")]
        public long CuratorId { get; set; }

        #endregion
    }
}
