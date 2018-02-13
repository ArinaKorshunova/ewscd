using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class PatientDisease : BaseEntity
    {
        #region Patient

        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        #endregion

        #region Disease

        public virtual Disease Disease { get; set; }

        [Required]
        [ForeignKey("Disease")]
        public long DiseaseId { get; set; }

        #endregion
    }
}
