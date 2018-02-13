using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Patient : BaseEntity
    {
        [Required]
        public string FIO { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
