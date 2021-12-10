using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Model
{
    public class HistoricoCorridas
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "CompetidorId não informado.")]
        public int CompetidorId { get; set; }
        [Required(ErrorMessage = "PistaCorridaId não informada.")]
        public int PistaCorridaId { get; set; }
        [Required(ErrorMessage = "Data da Corrida não informada.")]
        public DateTime DataCorrida { get; set; }
        [Required(ErrorMessage = "Tempo Gasto não informado.")]
        public decimal TempoGasto { get; set; }
    }
}
