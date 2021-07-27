using AutoMapper;
using BackendPrueba.Dtos;
using BackendPrueba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
            public AutoMapperProfiles()
            {
            CreateMap<Movie, MovieDTO>()
           .ForMember(X => X.Id, dto => dto.MapFrom(campo => campo.Id))
            .ForMember(X => X.Title, dto => dto.MapFrom(campo => campo.Title))
              .ForMember(X => X.Overview, dto => dto.MapFrom(campo => campo.Overview))
               .ForMember(X => X.Poster_Path, dto => dto.MapFrom(campo => "https://image.tmdb.org/t/p/w300" + campo.Poster_Path));

        }  
    }
}
