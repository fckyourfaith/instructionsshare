using cp2.Data;
using cp2.Models.BusinessModels;
using System.Collections.Generic;
using System.Linq;

namespace cp2.DataAccess
{
    public class InstructionRepository : IInstructionRepository
    {
        private readonly ApplicationDbContext context;

        public InstructionRepository(ApplicationDbContext applicationContext)
        {
            context = applicationContext;
        }

        public List<Instruction> GetInstructions()
        {
            return context.Instructions.ToList();
        }

        public void CreateInstruction(Instruction instruction)
        {
            context.Instructions.Add(instruction);
            context.SaveChanges();
        }
    }
}
