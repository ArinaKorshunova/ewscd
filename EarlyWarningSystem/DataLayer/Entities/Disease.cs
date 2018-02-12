using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Disease
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
