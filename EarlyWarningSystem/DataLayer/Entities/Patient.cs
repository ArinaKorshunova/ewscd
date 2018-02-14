using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Patient : BaseEntity
    {
        [Required]
        public string FIO { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string CityName { get; set; }


        #region Curator

        public virtual Employee Curator { get; set; }

        [Required]
        [ForeignKey("Curator")]
        public long CuratorId { get; set; }

        #endregion
        
        public string Disease { get; set; }
    }
}
