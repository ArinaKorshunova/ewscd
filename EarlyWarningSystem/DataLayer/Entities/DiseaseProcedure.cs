using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class DiseaseProcedure
    {
        [Key]
        public long Id { get; set; }
        
        public virtual Disease Disease { get; set; }

        [Required]
        [ForeignKey("Disease")]
        public long DiseaseId { get; set; }
        
        public virtual Procedure Procedure { get; set; }

        [Required]
        [ForeignKey("Procedure")]
        public long ProcedureId { get; set; }
    }
}
