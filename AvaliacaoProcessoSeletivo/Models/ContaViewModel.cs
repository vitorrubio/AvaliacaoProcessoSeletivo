using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoProcessoSeletivo.Models
{
    public class ContaViewModel
    {

        public int Id { get; set; }


        [MaxLength(50, ErrorMessage = "O nome tem que ter no máximo 50 caracteres")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }


        [MaxLength(500, ErrorMessage = "A descrição tem que ter no máximo 500 caracteres")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
