using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Procedure
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string ProcedureName { get; set; }
    }
}
