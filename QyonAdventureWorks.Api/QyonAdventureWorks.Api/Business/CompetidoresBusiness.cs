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

        public void Post(Competidor competidor)
        {
            var compet = new Competidor()
            {
                Nome = competidor.Nome,
                Sexo = competidor.Sexo,
                TemperaturaMediCorpo = competidor.TemperaturaMediCorpo,
                Peso = competidor.Peso,
                Altura = competidor.Altura
            };

            context.Competidores.Add(compet);
            context.SaveChanges();            
        }

        public void Put(Competidor competidor)
        {
            context.Competidores.Update(competidor);
            context.SaveChanges();
        }

        public void Delete(Competidor competidor)
        {
            context.Competidores.Remove(competidor);
            context.SaveChanges();
        }

        public void Delete(int competidorId)
        {
            var competidor = Get(competidorId);
            this.Delete(competidor);
        }
    }
}
