using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Disease : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
