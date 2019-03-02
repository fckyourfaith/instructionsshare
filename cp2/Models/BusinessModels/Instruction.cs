using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cp2.Models.BusinessModels
{
    [Table("Instructions")]
    public class Instruction
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string Theme { get; set; }
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
