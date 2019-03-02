using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cp2.Models.BusinessModels
{
    [Table("Likes")]

    public class Like
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CommentId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
