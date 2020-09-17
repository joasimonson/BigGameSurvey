using AutoMapper;
using BigGameSurvey.Api.DTO;
using BigGameSurvey.Api.Entities;

namespace BigGameSurvey.Api
{
    internal class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<RecordEntity, RecordDTO>()
                .ForMember(r => r.Genre, opt => opt.MapFrom(r => r.Game.Genre))
                .ReverseMap();
            CreateMap<GameEntity, RecordDTO.GameDTO>().ReverseMap();
            CreateMap<GenreEntity, RecordDTO.GenreDTO>().ReverseMap();
        }
    }
}