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

        public async Task<List<Competidor>> CompetidoresSemCorrida()
        {
            List<Competidor> listCompetidor = new List<Competidor>();

            var historico = context
                .HistoricoCorridas
                .Select(p => p.CompetidorId)
                .ToList();

            var competidores = context
                .Competidores
                .ToList();

            foreach (var comp in competidores)
            {
                if (!historico.Contains(comp.Id))
                {
                    listCompetidor.Add(comp);
                }
            }

            return listCompetidor;
        }

        public async Task<List<CompetidorTempoMedio>> TempoMedioCompetidores()
        {
            List<CompetidorTempoMedio> competidorTempoMedioList = new List<CompetidorTempoMedio>();

            var historico = context
                .HistoricoCorridas
                .Select(p => new { p.CompetidorId, p.TempoGasto})
                .ToList();

            var competidores = context.Competidores.ToList();

            foreach (var comp in competidores)
            {
                var listTempo = historico.Where(p => p.CompetidorId == comp.Id).Select(p => p.TempoGasto).ToList();
                var media = 0M;
                foreach (var item in listTempo)
                {
                    media += item;
                }
                media = media / listTempo.Count();

                var competidorTempoMedio = new CompetidorTempoMedio()
                {
                    Id = comp.Id,
                    Nome = comp.Nome,
                    TempoMedio = media
                };

                competidorTempoMedioList.Add(competidorTempoMedio);
            }

            return competidorTempoMedioList;
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
