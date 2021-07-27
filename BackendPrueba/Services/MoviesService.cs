using AutoMapper;
using BackendPrueba.Data;
using BackendPrueba.Dtos;
using BackendPrueba.Entities;
using BackendPrueba.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _appConfig;

        public MoviesService(IMoviesRepository moviesRepository,
                             IMapper mapper,
                             IConfiguration appConfig)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
            _appConfig = appConfig;
        }

        public async Task<List<MovieDTO>> Filter(MoviesFilterDTO filterDTO)
        {
            List<MovieDTO> listMovies = new List<MovieDTO>();

            if (!string.IsNullOrEmpty(filterDTO.Title))
            {
                listMovies = await FindMovieForName(filterDTO.Title);
            }
            else if (filterDTO.BetterRated)
            {
                listMovies = await FindBetterMoviesRated();
            }
            else if (filterDTO.MorePopulars)
            {
                listMovies = await FindMoviesMorePopular();
            }
            return listMovies;
        }

        public async Task<List<MovieDTO>> FindBetterMoviesRated()
        {
            var retryPolicy = RetryPolicy.GetRetryPolicy(_appConfig);

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var result = await _moviesRepository.FindBetterMoviesRated();
                return _mapper.Map<List<MovieDTO>>(result.Results);
            });
        }

        public async Task<LandingPageDTO> FindLatestsMovies()
        {
            var retryPolicy = RetryPolicy.GetRetryPolicy(_appConfig);

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var result = await _moviesRepository.FindLatestsMovies();
                LandingPageDTO landingPage = new LandingPageDTO();
                landingPage.LatestMovies = _mapper.Map<List<MovieDTO>>(result.Results);
                return landingPage;
            });        
        }

        public async Task<List<MovieDTO>> FindMovieForName(string name)
        {
            var retryPolicy = RetryPolicy.GetRetryPolicy(_appConfig);

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var result = await _moviesRepository.FindMovieForName(name);
                return _mapper.Map<List<MovieDTO>>(result.Results);
            });
        }

        public async Task<List<MovieDTO>> FindMoviesMorePopular()
        {
            var retryPolicy = RetryPolicy.GetRetryPolicy(_appConfig);

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var result = await _moviesRepository.FindMoviesMorePopular();
                return _mapper.Map<List<MovieDTO>>(result.Results);
            });
        }

        public async Task<MovieDTO> GetMovieDetail(int idMovie)
        {
            var retryPolicy = RetryPolicy.GetRetryPolicy(_appConfig);

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var result = await _moviesRepository.GetMovieDetail(idMovie);
                return _mapper.Map<MovieDTO>(result);
            });

        }
    }
}
