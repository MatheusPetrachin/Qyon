using QyonAdventureWorks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Business
{
    public class HistoricoCorridaBusiness
    {
        private readonly Context context;

        public HistoricoCorridaBusiness(Context context)
        {
            this.context = context;
        }

        public void Post(HistoricoCorrida historicoCorrida)
        {
            var historico = new HistoricoCorrida()
            {
                CompetidorId = historicoCorrida.CompetidorId,
                PistaCorridaId = historicoCorrida.PistaCorridaId,
                DataCorrida = historicoCorrida.DataCorrida,
                TempoGasto = historicoCorrida.TempoGasto
            };

            context.HistoricoCorridas.Add(historico);
            context.SaveChanges();
        }

        public void Put(HistoricoCorrida historicoCorrida)
        {
            context.HistoricoCorridas.Update(historicoCorrida);
            context.SaveChanges();
        }
    }
}
