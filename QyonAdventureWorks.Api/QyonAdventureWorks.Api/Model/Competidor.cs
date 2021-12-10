using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Model
{
    public class Competidor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não informado.")]
        [Column(TypeName = "VARCHAR(150)")]
        [MaxLength(40, ErrorMessage = "O campo nome pode ter no máximo 150 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sexo não informado.")]
        public char Sexo { get; set; }
        [Required(ErrorMessage = "Temperatura Media do Corpo não informada.")]
        public decimal TemperaturaMediCorpo { get; set; }
        [Required(ErrorMessage = "Peso não informado.")]
        public decimal Peso { get; set; }
        [Required(ErrorMessage = "Altura não informada.")]
        public decimal Altura { get; set; }
    }
}
