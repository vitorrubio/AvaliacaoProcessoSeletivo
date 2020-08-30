using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoProcessoSeletivo.Api.Domain
{
    [Table("Conta")]
    public class Conta
    {
        //[Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        //[Column("Nome")]
        [MaxLength(50, ErrorMessage = "O nome tem que ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        //[Column("Descricao")]
        [MaxLength(500, ErrorMessage = "A descrição tem que ter no máximo 500 caracteres")]
        public string Descricao { get; set; }
    }
}
