using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using MovieTrecker.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieTrecker.Services
{
    public class MovieService
    {
        private readonly List<Movie> _movies = new ();
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Data", "movies.json");

        public MovieService()
        {
            _movies = LoadFromFile();
        }

        private List<Movie> LoadFromFile()
        {

            var _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            if (!File.Exists(_filePath))
            {
                return new List<Movie>();
            }

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Movie>();
            }

            var movies = JsonSerializer.Deserialize<List<Movie>>(json, _jsonOptions);
            return movies ?? new List<Movie>();
        }

        private void SaveToFile()
        {
            var _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var json = JsonSerializer.Serialize(_movies, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            var result = _movies.Where(m => m.Genre == genre).ToList();

            return result;
        }

        public Movie GetMovie([FromRoute] int id)
        {
            return _movies[id];
        }
        public string AddMovie(Movie movie)
        {
            _movies.Add(movie);
            SaveToFile();
            return "Ок";
        }

        public string DeleteMovie(int id)
        {
            _movies.RemoveAt(id - 1);
            SaveToFile();
            return "Ok";
        }
        public string UpdateMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            _movies[id] = movie;
            SaveToFile();
            return "Ok";
        }
    }
}
