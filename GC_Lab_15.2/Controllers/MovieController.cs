using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_Lab_15._2.Models;
using GC_Lab_15._2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC_Lab_15._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IDAL dal;

        public MovieController(IDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public Object Get(string? category)
        {
            IEnumerable<Movie> movieList = null;

            if (string.IsNullOrEmpty(category))
            {
                movieList = dal.GetMoviesAll();
            } 
            else
            {
                movieList = dal.GetMoviesByCategory(category);
            }

            if (movieList is null)
            {
                return new { success = false };
            }

            return new { success = true, movieList };

        }

        [HttpGet("random")]
        public Object GetRandom(string? category)
        {
            Random r = new Random();
            Movie[] movies = null;

            if (string.IsNullOrEmpty(category))
            {
                movies = dal.GetMoviesAll().ToArray();
            }
            else
            {
                movies = dal.GetMoviesByCategory(category).ToArray();
            }


            if (movies is null)
            {
                return new { success = false };
            }


            Movie randomMovie = movies[r.Next(movies.Length)];
            return new { success = true, randomMovie };

        }

        [HttpGet("pick/{id}")]
        public Object GetPicks(int id, string? category)
        {
            int numOfMoviesToPick = id;
            Random r = new Random();
            List<Movie> movieList = null;

            if (string.IsNullOrEmpty(category))
            {
                movieList = dal.GetMoviesAll().ToList();
            }
            else
            {
                movieList = dal.GetMoviesByCategory(category).ToList();
            }

            if (movieList is null || movieList.Count == 0)
            {
                return new { success = false };
            }

            List<Movie> moviePicks = new List<Movie>();

            for (int i = 0; i < id && movieList.Count > 0; i++)
            {
                int randomIndex = r.Next(movieList.Count);
                moviePicks.Add(movieList[randomIndex]);
                movieList.RemoveAt(randomIndex);
            }

            return new { success = true, moviePicks };
        }

    }
}