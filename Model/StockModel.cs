
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_System_API.Model
{
    public class StockModel
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public double PrecoUnitario { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual ProdutoModel ProdutoModel { get; set; }
    }
}