using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
    public interface IGradeAPRRepository
    {
        CreateResponse CreateGradeAPR(GradeAPR income);
        string UpdateGradeAPR(GradeAPR income);
        List<GradeAPR> GetGradeAPRs(long settingId);
        string DeleteGradeAPR(int id);
        List<GradeAPRDetail> GetGradeAPRDetails(long settingId);
        GradeAPR LoadGradeAPRById(int id);
    }

}
