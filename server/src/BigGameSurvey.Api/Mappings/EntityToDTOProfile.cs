using AutoMapper;
using BigGameSurvey.Api.DTO;
using BigGameSurvey.Api.Entities;
using BigGameSurvey.Api.Enums;
using Microsoft.AspNetCore.Mvc.Paging;

namespace BigGameSurvey.Api
{
    internal class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));

            CreateMap<RecordEntity, RecordDTO>()
                .ForMember(d => d.Genre, opt => opt.MapFrom(s => s.Game.Genre))
                .ReverseMap();
            CreateMap<GameEntity, GameDTO>()
                .ForMember(d => d.Platform, opt => opt.MapFrom(s => ((PlatformEnum)s.Platform).ToString()))
                .ReverseMap();
            CreateMap<GenreEntity, GenreDTO>().ReverseMap();
        }
    }
}