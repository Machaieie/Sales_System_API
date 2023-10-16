using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_System_API.Model
{
   [Table("Produto")]
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [StringLength(255, ErrorMessage = "O campo Descrição deve ter no máximo 255 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        public int Categoria { get; set; }
    }
}