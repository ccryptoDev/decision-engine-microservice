using Microsoft.Extensions.Configuration;
using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
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
        public List<RuleResponseDTO> GetLoadRules(long setting_id)
        {
            List<RulesResponse> rules = _rulesRepository.GetLoadRules(setting_id);
            List<RuleResponseDTO> rulesResponseDTOs = Mapping.Mapper.Map<List<RulesResponse>, List<RuleResponseDTO>>(rules);
            return rulesResponseDTOs;

        }
      public  string InsertSettingRule(long setting_id)
        {
            return _rulesRepository.InsertSettingRule(setting_id);
        }
        public string CreateRuleDescription(RuleDescriptionRequestDTO rulesRequestDTO)
        {
            RuleDescription rule = Mapping.Mapper.Map<RuleDescriptionRequestDTO, RuleDescription>(rulesRequestDTO);
            return _rulesRepository.CreateRuleDescription(rule);

        }
        public string UpdateRuleDescription(UpdateRuleDescriptionRequestDTO updateRuleDescriptionRequestDTO)
        {
            RuleDescription ruleDescription = Mapping.Mapper.Map<UpdateRuleDescriptionRequestDTO, RuleDescription>(updateRuleDescriptionRequestDTO);
            return _rulesRepository.UpdateRuleDescription(ruleDescription);

        }
        public List<RuleDescriptionDTO> GetLoadRuleDescription()
        {
            List<RuleDescription> rules = _rulesRepository.GetLoadRuleDescription();
            List<RuleDescriptionDTO> rulesResponseDTOs = Mapping.Mapper.Map<List<RuleDescription>, List<RuleDescriptionDTO>>(rules);
            return rulesResponseDTOs;

        }
        public List<RuleDescriptionDTO> GetRuleDescriptions()
        {
            List<RuleDescription> rules = _rulesRepository.GetRuleDescriptions();
            List<RuleDescriptionDTO> rulesResponseDTOs = Mapping.Mapper.Map<List<RuleDescription>, List<RuleDescriptionDTO>>(rules);
            return rulesResponseDTOs;

        }

        public string AddOrUpdateSettingRule(List<SettingRuleDto> settingRulesDto)
        {
            var rule = Mapping.Mapper.Map<List<SettingRuleDto>, List<SettingRule>>(settingRulesDto);
            return _rulesRepository.AddOrUpdateSettingRule(rule);

        }
        public List<SettingRulesResponseDto> GetLoadSettingRules(long setting_id)
        {
            List<SettingRulesResponse> rules = _rulesRepository.GetLoadSettingRules(setting_id);
            List<SettingRulesResponseDto> rulesResponseDTOs = Mapping.Mapper.Map<List<SettingRulesResponse>, List<SettingRulesResponseDto>>(rules);
            return rulesResponseDTOs;

        }
      
    }
}
