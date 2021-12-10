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

        public async void Post(PistaCorrida pistaCorrida)
        {
            context.PistaCorridas.Add(pistaCorrida);
            await context.SaveChangesAsync();
        }

        public async void Put(PistaCorrida pistaCorrida)
        {
            context.PistaCorridas.Update(pistaCorrida);
            await context.SaveChangesAsync();
        }

        public async void Delete(PistaCorrida pistaCorrida)
        {
            context.PistaCorridas.Update(pistaCorrida);
            await context.SaveChangesAsync();
        }

        public void Delete(int pistaCorridaId)
        {
            var pistaCorrida = Get(pistaCorridaId);
            this.Delete(pistaCorrida);
        }
    }
}
