using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_System_API.Model
{
   [Table("Venda")]
    public class VendaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        [EnumDataType(typeof(StatusVenda), ErrorMessage = "O campo Status deve ser um valor válido.")]
        public int Status { get; set; }

        [Required(ErrorMessage = "O campo Preço Pago é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço pago deve ser maior que zero.")]
        public double PrecoPago { get; set; }
    }

    public enum StatusVenda
    {
        Pendente,
        Concluída,
        Cancelada
    }
}