using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
    public interface IOfferGradeService
    {
        CreateResponseDTO CreateOfferGrade(CreateOfferGradeRequestDTO offerGrade);
        string UpdateOfferGrade(UpdateGradeRequestDTO offerGrade);
        List<OfferGradeDTO> GetOfferGrades(long settingId);
        string DeleteOfferGrade(int id);
       
        OfferGradeDTO LoadOfferGradeById(int id);
        GradeAvgsDTO GetGradeAvgs(long grade_id, long settingId);
        List<ResponseOfferValueDTO> GetOfferValues(long offer_id);
    }
}
