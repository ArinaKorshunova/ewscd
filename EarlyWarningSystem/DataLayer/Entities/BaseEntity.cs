using System;
using DataLayer.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class BaseEntity : IDbEntityWithId
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
