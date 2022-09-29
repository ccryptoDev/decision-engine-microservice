using Microsoft.Extensions.Configuration;
using Rules_Engine.BAL.DTO;
using Rules_Engine.BAL.Interface;
using Rules_Engine.DAL.Interface;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Service
{
   public class RulesService : IRulesService
    {
        IRulesRepository _rulesRepository;

        public RulesService(IRulesRepository rulesRepository, IConfiguration configuration)
        {
            this._rulesRepository = rulesRepository;
        }
        public string CreateRule(RulesRequestDTO rulesRequestDTO)
        {
            Rule rule = Mapping.Mapper.Map<RulesRequestDTO, Rule>(rulesRequestDTO);
            return _rulesRepository.CreateRule(rule);

        }
        public string UpdateRule(UpdateRulesRequestDTO rulesRequestDTO)
        {
            Rule rule = Mapping.Mapper.Map<UpdateRulesRequestDTO, Rule>(rulesRequestDTO);
            return _rulesRepository.UpdateRule(rule);

        }
        public List<RuleResponseDTO> GetLoadRules()
        {
            List<RulesResponse> rules = _rulesRepository.GetLoadRules();
            List<RuleResponseDTO> rulesResponseDTOs = Mapping.Mapper.Map<List<RulesResponse>, List<RuleResponseDTO>>(rules);
            return rulesResponseDTOs;

        }
        public string CreateRuleDescription(RuleDescriptionRequestDTO rulesRequestDTO)
        {
            RuleDescription rule = Mapping.Mapper.Map<RuleDescriptionRequestDTO, RuleDescription>(rulesRequestDTO);
            return _rulesRepository.CreateRuleDescription(rule);

        }

        public List<RuleDescriptionDTO> GetLoadRuleDescription()
        {
            List<RuleDescription> rules = _rulesRepository.GetLoadRuleDescription();
            List<RuleDescriptionDTO> rulesResponseDTOs = Mapping.Mapper.Map<List<RuleDescription>, List<RuleDescriptionDTO>>(rules);
            return rulesResponseDTOs;

        }
    }
}
