using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_System_API.Model
{
    [Table("MovimentosStock")]
    public class MovimentosStockModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo StockId é obrigatório.")]
        public int StockId { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser um número positivo.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo Data deve ser uma data válida.")]
        public DateTime Data { get; set; }

        [ForeignKey("StockId")]
        public virtual required StockModel StockModel { get; set; }
    }
}