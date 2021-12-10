using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Model
{
    public class PistaCorrida
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição não informada.")]
        public string Descrição { get; set; }
    }
}
