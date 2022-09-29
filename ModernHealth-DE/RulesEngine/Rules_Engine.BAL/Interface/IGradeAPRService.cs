using Rules_Engine.BAL.DTO;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
    public interface IGradeAPRService
    {
        CreateResponseDTO CreateGradeAPR(CreateGradeRequestDTO income);
        string UpdateGradeAPR(UpdateGradeRequestDTO income);
        List<GradeAPRDTO> GetGradeAPRs();
        string DeleteGradeAPR(int id);

        GradeAPRDTO LoadGradeAPRById(int id);
    }
}
