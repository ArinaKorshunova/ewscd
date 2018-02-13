using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Procedure : BaseEntity
    {
        [Required]
        public string ProcedureName { get; set; }

        public string DEscription { get; set; }
    }
}
