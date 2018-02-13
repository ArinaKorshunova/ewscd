using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class DiseaseProcedure : BaseEntity
    {
        #region Disease

        public virtual Disease Disease { get; set; }

        [Required]
        [ForeignKey("Disease")]
        public long DiseaseId { get; set; }

        #endregion

        #region Procedure

        public virtual Procedure Procedure { get; set; }

        [Required]
        [ForeignKey("Procedure")]
        public long ProcedureId { get; set; }

        #endregion
    }
}
