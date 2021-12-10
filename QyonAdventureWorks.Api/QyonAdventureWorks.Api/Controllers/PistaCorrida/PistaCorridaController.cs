using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Api.Business;
using QyonAdventureWorks.Api.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QyonAdventureWorks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PistaCorridaController : Controller
    {
        private PistaCorridaBusiness business;
        public PistaCorridaController(PistaCorridaBusiness _business)
        {
            this.business = _business;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PistaCorrida>> Get(int Id)
        {
            try
            {
                var user = await business.Get(Id);
                if (user == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos a Pista...");
                    return BadRequest(ModelState);
                }
                return user;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("FilterName/{Nome}")]
        public async Task<ActionResult<List<Competidor>>> Get(string Nome)
        {
            try
            {
                var user = await business.Get(Nome);
                if (user == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos o competidor...");
                    return BadRequest(ModelState);
                }
                return user;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public void Post(PistaCorrida pistaCorrida)
        {
            business.Post(pistaCorrida);
        }

        [HttpPut]
        public void Put(PistaCorrida pistaCorrida)
        {
            business.Put(pistaCorrida);
        }

        [HttpDelete]
        public void Delete(PistaCorrida pistaCorrida)
        {
            business.Delete(pistaCorrida);
        }

        [HttpDelete("Id")]
        public void Delete(int pistaCorridaId)
        {
            business.Delete(pistaCorridaId);
        }
    }
}
