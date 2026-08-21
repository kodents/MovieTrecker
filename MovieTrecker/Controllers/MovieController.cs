using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTrecker.Models;

namespace MovieTrecker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie {
                Id = 0, 
                Director = "fawfwa", 
                Ganre = "fawfaw",
                Rating = 0,
                ReleaseYear = 2020,
                Status = Status.PlanToWatch,
                Title = "fawfaw",
                WatchedDate = null
            },
             new Movie {
                Id = 1,
                Director = "fa312wfwa",
                Ganre = "fawfaw",
                Rating = 0,
                ReleaseYear = 2023,
                Status = Status.Watching,
                Title = "gawgawgaw",
                WatchedDate = null
            }
        };

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return Movies;
        }

        [HttpPost]
        public string AddMovie(Movie movie)
        {
            Movies.Add(movie);
            return "Ок";
        }

        [HttpDelete]
        public string DeleteMovie(int id)
        {
            Movies.RemoveAt(id);
            return "Ok";
        }

        [HttpPut("{id}")]
        public string UpdateMovie([FromRoute] int id, [FromBody] Movie movie) 
        {
            Movies[id] = movie;
            return "Ok";
        }
    }
}
