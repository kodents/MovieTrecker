using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTrecker.Dtos;
using MovieTrecker.Models;
using MovieTrecker.Services;

namespace MovieTrecker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return _movieService.GetMovies();
        }

        [HttpGet("genre/{genre}")]
        public List<Movie> GetMoviesByGenre([FromRoute] string genre)
        {
            return _movieService.GetMoviesByGenre(genre);
        }

        [HttpGet("top-rated")]
        public List<Movie> GetMoviesByGenre([FromQuery] int count)
        {
            return _movieService.GetTopRatedMovies(count);
        }

        [HttpGet("statistics")]
        public Statistics GetStatistics()
        {
            return _movieService.GetStatistics();
        }


        [HttpGet("{id}")]
        public Movie GetMovie([FromRoute] int id)
        {
            return _movieService.GetMovie(id);
        }

        [HttpPost]
        public string AddMovie(Movie movie)
        {
            _movieService.AddMovie(movie);
            return "Ок";
        }

        [HttpDelete]
        public string DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return "Ok";
        }

        [HttpPut("{id}")]
        public string UpdateMovie([FromRoute] int id, [FromBody] Movie movie) 
        {
            _movieService.UpdateMovie(id, movie);
            return "Ok";
        }
    }
}
