using BackendPrueba.Dtos;
using BackendPrueba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Services
{
    public interface IMoviesService
    {
        Task<LandingPageDTO> FindLatestsMovies();

        Task<List<MovieDTO>> FindBetterMoviesRated();

        Task<List<MovieDTO>> FindMoviesMorePopular();

        Task<List<MovieDTO>> FindMovieForName(string name);

        Task<List<MovieDTO>> Filter(MoviesFilterDTO filterDTO);

        Task<MovieDTO> GetMovieDetail(int idMovie);
    }
}
