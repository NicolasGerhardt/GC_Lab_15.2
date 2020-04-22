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
        public Movie GetRandom(string? category)
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



            Movie randomMovie = movies[r.Next(movies.Length)];
            return randomMovie;

        }



    }
}