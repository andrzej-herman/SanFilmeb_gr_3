using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataJsonCreator
{
    internal class FileParser
    {
        private readonly string path;

        public FileParser(string path)
        {
            this.path = path;
        }

        public List<Movie> GetMovies()
        {
            Console.WriteLine();
            Console.WriteLine(" Rozpoczynam parsowanie pliku ...");
            var result = new List<Movie>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split("\t");
                    if (parts.Length == 10)
                    {
                        result.Add(CreateMovie(parts));
                    }
                }
            }

            Console.WriteLine($" Utworzono {result.Count} filmów");
            return result;
        }

        private Movie CreateMovie(string[] parts)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid().ToString(),
                Title = parts[0],
                OriginalTitle = parts[1],
                Director = parts[2],
                Genre = parts[3],
                Screenplay = parts[4],
                ReleaseYear = int.TryParse(parts[5], out int y) ? y : 2000,
                Trailer = parts[8],
                Description = parts[9]
            };

            var actors = parts[6].Split(",");
            foreach (var actor in actors)
            {
                movie.Cast.Add(actor.Trim());
            }

            var images = parts[7].Split(",");
            foreach (var img in images)
            {
                movie.Images.Add(img.Trim());
            }

            return movie;
        }
    }
}




//public List<string> Cast { get; set; } = new();
//public List<string> Images { get; set; } = new();
//public string Trailer { get; set; }
//public string Description { get; set; }