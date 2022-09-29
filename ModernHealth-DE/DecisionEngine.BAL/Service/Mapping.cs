
using AutoMapper;
using DecisionEngine.BAL.DTO;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace DecisionEngine.BAL.Service
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
            CreateMap<UpdateRuleDescriptionRequestDTO, RuleDescription>();
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
            CreateMap<GradeAPRDetail, GradeAPRDetailDTO>();

            CreateMap<CreateOfferRequestDTO, Offer>();
            CreateMap<OfferDTO, Offer>().ReverseMap();

            CreateMap<OfferValueDTO, OfferValue>().ReverseMap();
            CreateMap<CreateOfferValueRequestDTO, OfferValue>();
            CreateMap<OfferValueDetail, OfferValueDetailDTO>();

            CreateMap<CreateOfferGradeRequestDTO, OfferGrade>();
            CreateMap<OfferGradeDetail, OfferGradeDTO>();
            CreateMap<GradeAvgs, GradeAvgsDTO>();
            CreateMap<ResponseOfferValue, ResponseOfferValueDTO>();

            CreateMap<TermDTO, Term>().ReverseMap();
            CreateMap<CreateTermRequestDTO, Term>();
            CreateMap<TermDtl, TermDTO>();

            CreateMap<TermGradeDTO, TermGrade>().ReverseMap();
            CreateMap<CreateTermGradeRequestDTO, TermGrade>();
            CreateMap<TermGradeDetail, TermGradeDetailDTO>();

            CreateMap<SettingRuleDto, SettingRule>();
            CreateMap<SettingRulesResponse, SettingRulesResponseDto>();
        }
    }
}
