using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Business
{
    public class PistaCorridaBusiness
    {
        private readonly Context context;

        public PistaCorridaBusiness(Context context)
        {
            this.context = context;
        }


        public async Task<List<PistaCorrida>> PistasUtilizadas()
        {
            List<PistaCorrida> listPistas = new List<PistaCorrida>();

            var historico = context
                .HistoricoCorridas
                .Select(p => p.PistaCorridaId)
                .ToList();

            var pistas = context
                .PistaCorridas
                .ToList();

            foreach (var pist in pistas)
            {
                if (historico.Contains(pist.Id))
                {
                    listPistas.Add(pist);
                }
            }  

            return listPistas;
        }

        public PistaCorrida Get(int Id)
        {
            return context
                .PistaCorridas
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }

        public async Task<List<PistaCorrida>> Get(string descrição)
        {
            return await context
                .PistaCorridas
                .Where(x => x.Descrição.Contains(descrição))
                .ToListAsync();
        }

        public void Post(PistaCorrida pistaCorrida)
        {
            var PistaCorrida = new PistaCorrida()
            {
                Descrição = pistaCorrida.Descrição
            };

            context.PistaCorridas.Add(pistaCorrida);
            context.SaveChanges();
        }

        public void Put(PistaCorrida pistaCorrida)
        {
            context.PistaCorridas.Update(pistaCorrida);
            context.SaveChanges();
        }

        public void Delete(PistaCorrida pistaCorrida)
        {
            context.PistaCorridas.Remove(pistaCorrida);
            context.SaveChanges();
        }

        public void Delete(int pistaCorridaId)
        {
            var pistaCorrida = Get(pistaCorridaId);
            this.Delete(pistaCorrida);
        }
    }
}
