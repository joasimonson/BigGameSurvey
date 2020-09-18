using AutoMapper;
using BigGameSurvey.Api.DTO;
using BigGameSurvey.Api.Entities;
using Microsoft.AspNetCore.Mvc.Paging;
using System;

namespace BigGameSurvey.Api
{
    internal class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));
            CreateMap<RecordEntity, RecordDTO>()
                .ForMember(r => r.Genre, opt => opt.MapFrom(r => r.Game.Genre))
                .ReverseMap();
            CreateMap<GameEntity, RecordDTO.GameDTO>().ReverseMap();
            CreateMap<GenreEntity, RecordDTO.GenreDTO>().ReverseMap();
        }
    }
}