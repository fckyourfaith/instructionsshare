using System.Collections.Generic;
using cp2.Models.BusinessModels;

namespace cp2.DataAccess
{
    public interface IInstructionRepository
    {
        void CreateInstruction(Instruction instruction);
        List<Instruction> GetInstructions();
    }
}