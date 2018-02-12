using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Patient
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
