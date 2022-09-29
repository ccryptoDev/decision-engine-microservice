using Microsoft.Extensions.Configuration;
using Rules_Engine.BAL.DTO;
using Rules_Engine.BAL.Interface;
using Rules_Engine.DAL.Interface;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rules_Engine.BAL.Service
{
    public class OfferLoanService : IOfferLoanService
    {
        IOfferLoanRepository _offerLoanRepository;

        public OfferLoanService(IOfferLoanRepository offerLoanRepository, IConfiguration configuration)
        {
            this._offerLoanRepository = offerLoanRepository;
        }
        public CreateResponseDTO CreateOfferLoan(CreateOfferLoanRequestDTO insertOfferLoanRequestDTO)
        {
            OfferLoan offerLoan = Mapping.Mapper.Map<CreateOfferLoanRequestDTO, OfferLoan>(insertOfferLoanRequestDTO);
            CreateResponse createResponse = _offerLoanRepository.CreateOfferLoan(offerLoan);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string UpdateOfferLoan(UpdateOfferLoanRequestDTO offerLoanDTO)
        {
            OfferLoan offerLoan = Mapping.Mapper.Map<UpdateOfferLoanRequestDTO, OfferLoan>(offerLoanDTO);
            return _offerLoanRepository.UpdateOfferLoan(offerLoan);

        }
        public string DeleteOfferLoan(int id)
        {
            return _offerLoanRepository.DeleteOfferLoan(id);

        }
        public OfferLoanDTO LoadOfferLoanById(int id)
        {
            OfferLoan offerLoan = _offerLoanRepository.LoadOfferLoanById(id);
            OfferLoanDTO offerLoanDTO = Mapping.Mapper.Map<OfferLoan, OfferLoanDTO>(offerLoan);
            return offerLoanDTO;


        }
        public List<OfferLoanDTO> GetOfferLoans()
        {
            List<OfferLoan> offerLoans = _offerLoanRepository.GetOfferLoans();
            List<OfferLoanDTO> offerLoanDTOs = Mapping.Mapper.Map<List<OfferLoan>, List<OfferLoanDTO>>(offerLoans);
            return offerLoanDTOs;

        }

        public List<Dictionary<string, object>> GetOfferLoansWithTerms(string grade = null)
        {
            List<OfferLoanResult> offerLoanWithTerms = _offerLoanRepository.GetOfferLoanWithTerms(grade);
            List<Dictionary<string, object>> result = GetOfferLoanTermDictionary(offerLoanWithTerms);
            return result;
        }


        private List<Dictionary<string, object>> GetOfferLoanTermDictionary(List<OfferLoanResult> result)
        {
            List<Dictionary<string, object>> res = new List<Dictionary<string, object>>();

            var oltGroup = result.GroupBy(x => x.Grade);
            foreach (var grp in oltGroup)
            {
                Dictionary<string, object> gpDict = new Dictionary<string, object>();
                gpDict.Add("Grade", grp.Key);

                //Loan Amount OfferGiven 
                foreach (var gv in grp)
                {
                    gpDict.Add(gv.OfferName, gv.Amount);
                }

                //Offered Term (Monthly) * Rule-78
                foreach (var gv in grp)
                {
                    gpDict.Add(gv.TermName, gv.TermValue);
                }

                //avg monthly payment
                foreach (var gv in grp)
                {
                    gpDict.Add("avg_" + gv.TermName, gv.AvgMonthlyPayment);
                }

                // Max monthly payment		
                foreach (var gv in grp)
                {
                    gpDict.Add("max_" + gv.TermName, gv.MaxMonthlyPayment);
                }

                res.Add(gpDict);
            }
            return res;
        }
    }
}
