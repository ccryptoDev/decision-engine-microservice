using DecisionEngine.BAL.DTO;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
    public interface IGradeAPRService
    {
        CreateResponseDTO CreateGradeAPR(CreateGradeRequestDTO income);
        string UpdateGradeAPR(UpdateGradeRequestDTO income);
        List<GradeAPRDTO> GetGradeAPRs(long settingId);
        string DeleteGradeAPR(int id);
        List<GradeAPRDetailDTO> GetGradeAPRDetails(long settingId);
        GradeAPRDTO LoadGradeAPRById(int id);
    }
}
