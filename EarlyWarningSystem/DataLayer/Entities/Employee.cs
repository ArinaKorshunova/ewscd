using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        public string FIO { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Role { get; set; }

        public string Dscription { get; set; }

        #region User
        
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        
        #endregion
    }
}
