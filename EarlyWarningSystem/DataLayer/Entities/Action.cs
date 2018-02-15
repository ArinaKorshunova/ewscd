using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Action : BaseEntity
    {
        #region Doctor 

        public virtual Employee Doctor { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }

        #endregion

        #region Patient

        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        #endregion

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string DoctorsCommnet { get; set; }

        public bool WasHeld { get; set; }

        [Required]
        public string KindAction { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public string Title {
            get
            {
                return string.Format("{0} {1} - {2} {3}", Doctor.FIO, AppointmentDate.ToString("dd.MM.yyyy"), Description, WasHeld ? "(Проведено)" : "(Не проведено)");
            }
        }

        [NotMapped]
        public string TitleForDoctor
        {
            get
            {
                return string.Format("{0} | {1} - {2}", AppointmentDate.ToString("dd.MM.yyyy"), KindAction, Description);
            }
        }
    }
}
