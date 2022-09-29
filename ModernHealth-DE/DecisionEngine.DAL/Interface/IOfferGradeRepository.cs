using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
    public interface IOfferGradeRepository
    {
        CreateResponse CreateOfferGrade(OfferGrade income);
        string UpdateOfferGrade(OfferGrade income);
        List<OfferGradeDetail> GetOfferGrades(long settingId);
        string DeleteOfferGrade(int id);

        OfferGradeDetail LoadOfferGradeById(int id);
        GradeAvgs GetGradeAvgs(long grade_id, long settingId);
        List<ResponseOfferValue> GetOfferValues(long offer_id);
    }
}
