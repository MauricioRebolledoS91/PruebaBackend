using BackendPrueba.Entities;
using BackendPrueba.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Data
{
    public interface IMoviesRepository
    {
        Task<ApiResponse> FindLatestsMovies();

        Task<ApiResponse> FindBetterMoviesRated();

        Task<ApiResponse> FindMoviesMorePopular();

        Task<ApiResponse> FindMovieForName(string name);

        Task<Movie> GetMovieDetail(int movieId);
    }
}
