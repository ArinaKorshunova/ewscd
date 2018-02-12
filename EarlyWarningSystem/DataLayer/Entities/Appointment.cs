using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Appointment
    {
        [Key]
        public long Id { get; set; }
       
        public virtual Doctor Doctor { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }

        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string DoctorsCommnet { get; set; }

        public bool WasHeld { get; set; }
    }
}
