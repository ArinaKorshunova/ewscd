using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Curator : BaseEntity
    {
        [Required]
        public string FIO { get; set; }

        [Required]
        public string CityName { get; set; }

        #region User

        public virtual User User { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }

        #endregion
    }
}
