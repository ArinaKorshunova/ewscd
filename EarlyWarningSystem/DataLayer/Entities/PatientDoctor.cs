using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class PatientDoctor : BaseEntity
    {
        #region Patient

        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        #endregion

        #region Doctor

        public virtual Employee Doctor { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }

        #endregion
    }
}
