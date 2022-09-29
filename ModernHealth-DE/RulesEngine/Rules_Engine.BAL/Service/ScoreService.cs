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
   public class ScoreService : IScoreService
    {
        IScoreRepository _scoreRepository;

        public ScoreService(IScoreRepository scoreRepository, IConfiguration configuration)
        {
            this._scoreRepository = scoreRepository;
        }
        public CreateResponseDTO CreateScore(CreateScoreRequestDTO insertScoreRequestDTO)
        {
            Score score = Mapping.Mapper.Map<CreateScoreRequestDTO, Score>(insertScoreRequestDTO);
            CreateResponse createResponse = _scoreRepository.CreateScore(score);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string UpdateScore(UpdateScoreRequestDTO scoreDTO)
        {
            Score score = Mapping.Mapper.Map<UpdateScoreRequestDTO, Score>(scoreDTO);
            return _scoreRepository.UpdateScore(score);

        }
        public string DeleteScore(int id)
        {
            return _scoreRepository.DeleteScore(id);

        }
        public ScoreDTO LoadScoreById(int id)
        {
            Score score = _scoreRepository.LoadScoreById(id);
            ScoreDTO scoreDTO = Mapping.Mapper.Map<Score, ScoreDTO>(score);
            return scoreDTO;


        }
        public List<ScoreDTO> GetScores()
        {
            List<Score> scores = _scoreRepository.GetScores();
            List<ScoreDTO> scoreDTOs = Mapping.Mapper.Map<List<Score>, List<ScoreDTO>>(scores);
            return scoreDTOs;

        }
    }
}
