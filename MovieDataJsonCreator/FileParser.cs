using SanFilmotekaCommon;
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
                    if (parts.Length == 11)
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
                ReleaseDate = Convert.ToDateTime(parts[1]),
                Description = parts[2],
                Genre= parts[8],
                Image= parts[9],
                Trailer= parts[10],
            };

            movie.Cast.Add(parts[3]);
            movie.Cast.Add(parts[4]);
            movie.Cast.Add(parts[5]);
            movie.Cast.Add(parts[6]);
            movie.Cast.Add(parts[7]);
            return movie;
        }
    }
}




//public List<string> Cast { get; set; } = new();
//public List<string> Images { get; set; } = new();
//public string Trailer { get; set; }
//public string Description { get; set; }