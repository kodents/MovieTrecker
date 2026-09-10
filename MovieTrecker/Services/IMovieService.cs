using Microsoft.AspNetCore.Mvc;
using MovieTrecker.Dtos;
using MovieTrecker.Models;

namespace MovieTrecker.Services
{
    public interface IMovieService
    {
        public List<Movie> GetMovies();
        public List<Movie> GetMoviesByGenre(string genre);
        public List<Movie> GetTopRatedMovies(int count);
        public Statistics GetStatistics();
        public string AddMovie(Movie movie);
        public Movie GetMovie(int id);
        public string DeleteMovie(int id);
        public string UpdateMovie(int id, Movie movie);

    }
}
