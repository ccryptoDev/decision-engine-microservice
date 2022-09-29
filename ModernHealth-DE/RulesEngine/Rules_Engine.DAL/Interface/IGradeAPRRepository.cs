using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
    public interface IGradeAPRRepository
    {
        CreateResponse CreateGradeAPR(GradeAPR income);
        string UpdateGradeAPR(GradeAPR income);
        List<GradeAPR> GetGradeAPRs();
        string DeleteGradeAPR(int id);

        GradeAPR LoadGradeAPRById(int id);
    }

}
