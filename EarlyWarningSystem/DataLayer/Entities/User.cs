using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
