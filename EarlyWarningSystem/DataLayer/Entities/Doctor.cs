using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Doctor
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string Specialization { get; set; }
    }
}
