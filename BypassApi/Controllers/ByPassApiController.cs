﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BypassApi.Interfaces;
using BypassApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BypassApi.Controllers
{

    [ApiController]
    [Route("/api")]
    public class ByPassApiController : ControllerBase
    {
        private readonly IMovieAPIRepository _movieAPIRepository;

        public ByPassApiController(IMovieAPIRepository movieAPIRepository)
        {
            _movieAPIRepository = movieAPIRepository;
        }

        [HttpGet]
        public Task<MovieViewModel> Get(int Id)
        {
            try
            {
                return _movieAPIRepository.GetMovieById(Id);
            }
            catch (Exception)
            {
                throw new Exception("Un unexpected error occurred");
            }
        }
    }
}
