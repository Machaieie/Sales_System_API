using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_System_API.Model
{
    [Table("Carinho")]
    public class CarinhoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo VendaId é obrigatório.")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? CodigoProduto { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser um número positivo.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Preco { get; set; }

        [ForeignKey("VendaId")]
        public virtual required VendaModel VendaModel { get; set; }

        [ForeignKey("Codigo")] // Chave estrangeira para o CodigoProduto
        public virtual required ProdutoModel ProdutoModel { get; set; }
    }
}
