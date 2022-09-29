using AutoMapper;
using Rules_Engine.BAL.DTO;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Rules_Engine.BAL.Service
{
   public class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RulesRequestDTO, Rule>();
            CreateMap<RulesResponse, RuleResponseDTO>();
            CreateMap<RuleDescriptionRequestDTO, RuleDescription>();
            CreateMap<RuleDescription, RuleDescriptionDTO>();
            CreateMap<UpdateRulesRequestDTO, Rule>();
            CreateMap<GradeDTO, Grade>().ReverseMap();
            CreateMap<CreateReguestGradeDTO, Grade>();
            CreateMap<CreateScoreRequestDTO, Score>();
            CreateMap<UpdateScoreRequestDTO, Score>();
            CreateMap<ScoreDTO, Score>().ReverseMap();
            CreateMap<CreateResponse, CreateResponseDTO>();

            CreateMap<CreateIncomeRequestDTO, Income>();
            CreateMap<UpdateIncomeRequestDTO, Income>();
            CreateMap<IncomeDTO, Income>().ReverseMap();

            CreateMap<CreateGradeRequestDTO, GradeAPR>();
            CreateMap<UpdateGradeRequestDTO, GradeAPR>();
            CreateMap<GradeAPRDTO, GradeAPR>().ReverseMap();

            CreateMap<CreateOfferLoanRequestDTO, OfferLoan>();
            CreateMap<UpdateOfferLoanRequestDTO, OfferLoan>();
            CreateMap<OfferLoanDTO, OfferLoan>().ReverseMap();

            CreateMap<CreateOfferedTermRequestDTO, OfferedTerm>();
            CreateMap<UpdateOfferedTermRequestDTO, OfferedTerm>();
            CreateMap<OfferedTermDTO, OfferedTerm>().ReverseMap();

        }
    }
}
