using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cp2.Models.BusinessModels
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
                
        public int InstructionId { get; set; }
        public virtual Instruction Instruction { get; set; }
    }
}
