using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTrecker.Models;
using MovieTrecker.Services;

namespace MovieTrecker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService movieService;

        public MovieController()
        {
            movieService = new MovieService();
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return movieService.GetMovies();
        }

        [HttpGet("genre/{genre}")]
        public List<Movie> GetMoviesByGenre([FromRoute] string genre)
        {
            return movieService.GetMoviesByGenre(genre);
        }

        [HttpGet("{id}")]
        public Movie GetMovie([FromRoute] int id)
        {
            return movieService.GetMovie(id);
        }

        [HttpPost]
        public string AddMovie(Movie movie)
        {
            movieService.AddMovie(movie);
            return "Ок";
        }

        [HttpDelete]
        public string DeleteMovie(int id)
        {
            movieService.DeleteMovie(id);
            return "Ok";
        }

        [HttpPut("{id}")]
        public string UpdateMovie([FromRoute] int id, [FromBody] Movie movie) 
        {
            movieService.UpdateMovie(id, movie);
            return "Ok";
        }
    }
}
