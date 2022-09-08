using AutoMapper;
using MinimalAPI_2.DTOs;
using MinimalAPI_2.Models;

namespace MinimalAPI_2.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // Source -> Target
            CreateMap<Movie, MovieReadDTO>();
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}
