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
    public class CompetidoresController : ControllerBase
    {
        private CompetidoresBusiness business;
        public CompetidoresController(CompetidoresBusiness _business)
        {
            this.business = _business;
        }

        [HttpGet("CompetidoresSemCorrida")]
        public async Task<ActionResult<List<Competidor>>> GetCompetidoresSemCorrida()
        {
            try
            {
                var list = await business.CompetidoresSemCorrida();
                if (list == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos nenhum competidor sem competir...");
                    return BadRequest(ModelState);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("TempoMedioCompetidores")]
        public async Task<ActionResult<List<CompetidorTempoMedio>>> GetTempoMedioCompetidores()
        {
            try
            {
                var list = await business.TempoMedioCompetidores();
                if (list == null)
                {
                    ModelState.AddModelError("Error", "Não encontramos nenhum competidor...");
                    return BadRequest(ModelState);
                }
                return list;
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Competidor>> Get(int Id)
        {
            try
            {
                var user = business.Get(Id);
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
        public void Post(Competidor competidor)
        {
            business.Post(competidor);                         
        }

        [HttpPut]
        public void Put(Competidor competidor)
        {
            business.Put(competidor);
        }

        [HttpDelete]
        public void Delete(Competidor competidor)
        {
            business.Delete(competidor);
        }

        [HttpDelete("Id")]
        public void Delete(int competidorId)
        {
            business.Delete(competidorId);
        }


    }
}
