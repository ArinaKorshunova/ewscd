using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class PatientDisease
    {
        [Key]
        public long Id { get; set; }
        
        public virtual Patient Patient { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public long PatientId { get; set; }

        public virtual Disease Disease { get; set; }

        [Required]
        [ForeignKey("Disease")]
        public long DiseaseId { get; set; }
    }
}
