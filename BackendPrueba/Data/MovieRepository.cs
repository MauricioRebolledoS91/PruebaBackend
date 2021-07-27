using BackendPrueba.Entities;
using BackendPrueba.Utilidades;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendPrueba.Data
{
    public class MovieRepository : IMoviesRepository
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;
        private RestClient _client;

        public MovieRepository(IConfiguration appSettings)
        {
            _apiUrl = appSettings.GetValue<string>("api_url");
            _apiKey = appSettings.GetValue<string>("api_key");
            _client = new RestClient(_apiUrl);
        }

        public async Task<ApiResponse> FindBetterMoviesRated()
        {
            var request = new RestRequest("movie/top_rated?" + _apiKey, Method.GET);
            var result = await _client.ExecuteAsync(request);
            var movies = JsonConvert.DeserializeObject<ApiResponse>(result.Content);
            return movies;
        }

        public async Task<ApiResponse> FindLatestsMovies()
        {
            var request = new RestRequest("movie/now_playing?" + _apiKey, Method.GET);
            var result = await _client.ExecuteAsync(request);
            var movies = JsonConvert.DeserializeObject<ApiResponse>(result.Content);
            return movies;
        }

        public async Task<ApiResponse> FindMovieForName(string name)
        {
            var request = new RestRequest("search/movie?" + _apiKey + "&query=" + name, Method.GET);
            var result = await _client.ExecuteAsync(request);
            var movies = JsonConvert.DeserializeObject<ApiResponse>(result.Content);
            return movies;
        }

        public async Task<ApiResponse> FindMoviesMorePopular()
        {
            var request = new RestRequest("movie/popular?" + _apiKey, Method.GET);
            var result = await _client.ExecuteAsync(request);
            var movies = JsonConvert.DeserializeObject<ApiResponse>(result.Content);
            return movies;
        }

        public async Task<Movie> GetMovieDetail(int movieId)
        {
            var request = new RestRequest("movie/" + movieId.ToString() + "?" + _apiKey, Method.GET);
            var result = await _client.ExecuteAsync(request);
            var movie = JsonConvert.DeserializeObject<Movie>(result.Content);
            return movie;
        }
    }
}
