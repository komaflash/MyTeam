

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTeam.Entities
{

    public class Team : ITimestampedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public DateTime CreatedAt { get ;set; }
        public DateTime LastModified { get ;set; }
    }
}