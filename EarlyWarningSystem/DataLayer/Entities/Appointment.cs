﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Appointment : BaseEntity
    {
        #region Doctor 

        public virtual Doctor Doctor { get; set; }

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
    }
}
