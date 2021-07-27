
using AutoMapper;
using BackendPrueba.Data;
using BackendPrueba.Dtos;
using BackendPrueba.Entities;
using BackendPrueba.Services;
using BackendPrueba.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(
            IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("LatestMovies")]
        public async Task<ActionResult<LandingPageDTO>> LatestMovies()
        {
            var movies = await _moviesService.FindLatestsMovies();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> Filter([FromQuery] MoviesFilterDTO filterDTO)
        {
            var movies = await _moviesService.Filter(filterDTO);

            if(movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("filter/{id}")]
        public async Task<ActionResult<MovieDTO>> Filter(int id)
        {
            var movie = await _moviesService.GetMovieDetail(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
