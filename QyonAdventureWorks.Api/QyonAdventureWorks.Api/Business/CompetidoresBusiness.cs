using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Business
{
    public class CompetidoresBusiness
    {
        private readonly Context context;

        public CompetidoresBusiness(Context context)
        {
            this.context = context;
        }

        public Competidor Get(int Id)
        {
            return context
                .Competidores
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }

        public async Task<List<Competidor>> Get(string nome)
        {
            return await context
                .Competidores
                .Where(x => x.Nome == nome)
                .ToListAsync();
        }

        public async void Post(Competidor competidor)
        {
            context.Competidores.Add(competidor);
            await context.SaveChangesAsync();            
        }

        public async void Put(Competidor competidor)
        {
            context.Competidores.Update(competidor);
            await context.SaveChangesAsync();
        }

        public async void Delete(Competidor competidor)
        {
            context.Competidores.Update(competidor);
            await context.SaveChangesAsync();
        }

        public void Delete(int competidorId)
        {
            var competidor = Get(competidorId);
            this.Delete(competidor);
        }
    }
}
