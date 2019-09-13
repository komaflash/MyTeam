

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTeam.Entities
{
    public class Member : ITimestampedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set;}
        public Nullable<DateTime> Born { get; set; }
      
        public int TeamId { get; set; }

        // [ForeignKey("TeamId")]
        // public virtual Team Team { get; set; }
        public DateTime CreatedAt { get ;set; }
        public DateTime LastModified { get ;set; }
    }
}