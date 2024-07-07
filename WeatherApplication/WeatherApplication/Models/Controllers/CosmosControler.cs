﻿using Microsoft.AspNetCore.Mvc;

namespace WeatherApplication.Models.Controllers
{
    [Route("/cosmos")]
    public class CosmosController : ControllerBase
    {
        private readonly DemoContext _dbContext;
        private static bool _ensureCreated { get; set; } = false;

        public CosmosController(DemoContext dbContext)
        {
            _dbContext = dbContext;

            if (!_ensureCreated)
            {
                _dbContext.Database.EnsureCreated();
                _ensureCreated = true;
            }
        }
    }
}
