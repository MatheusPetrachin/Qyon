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

        [HttpGet]
        public async Task<ActionResult<List<PistaCorrida>>> Get()
        {
            try
            {
                var pistas = await business.PistasUtilizadas();
                if (pistas == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos nenhuma pista utilizada...");
                    return BadRequest(ModelState);
                }
                return pistas;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PistaCorrida>> Get(int id)
        {
            try
            {
                var pista = business.Get(id);
                if (pista == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos a Pista...");
                    return BadRequest(ModelState);
                }
                return pista;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("FilterDescription/{description}")]
        public async Task<ActionResult<List<PistaCorrida>>> Get(string description)
        {
            try
            {
                var pistas = await business.Get(description);
                if (pistas == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos nenhuma pista com essa Descrição...");
                    return BadRequest(ModelState);
                }
                return pistas;
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
