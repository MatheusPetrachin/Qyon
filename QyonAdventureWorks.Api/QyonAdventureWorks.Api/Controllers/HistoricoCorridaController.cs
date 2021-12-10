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
    public class HistoricoCorridaController : ControllerBase
    {
        private HistoricoCorridaBusiness business;
        public HistoricoCorridaController(HistoricoCorridaBusiness _business)
        {
            this.business = _business;
        }

        [HttpPost]
        public void Post(HistoricoCorrida historicoCorrida)
        {
            business.Post(historicoCorrida);
        }

        [HttpPut]
        public void Put(HistoricoCorrida historicoCorrida)
        {
            business.Put(historicoCorrida);
        }
    }
}
