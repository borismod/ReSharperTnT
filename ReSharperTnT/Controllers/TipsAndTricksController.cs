﻿using System.Web.Http;
using ReSharperTnT.Engine;
using ReSharperTnT.Models;

namespace ReSharperTnT.Controllers
{
    public class TipsAndTricksController : ApiController
    {
        private readonly ITipsAndTricksRepository _tipsAndTricksRepository;

        public TipsAndTricksController(ITipsAndTricksRepository tipsAndTricksRepository)
        {
            _tipsAndTricksRepository = tipsAndTricksRepository;
        }

        // GET api/<controller>
        public ResharperTip Get()
        {
            return _tipsAndTricksRepository.GetRandom();
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }
    }
}