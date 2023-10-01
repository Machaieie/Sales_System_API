using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_System_API.Model
{
    public class CarinhoModel
    {
        public int Id {get; set;}
        public int VendaId {get; set;}
        public int ProdutoId {get;set;}
        public int quantidade {get; set;}
        public double Preco {get; set;}

        [ForeignKey("VendaId")]
        public virtual VendaModel VendaModel{get; set;}

        [ForeignKey("ProdutoId")]
        public virtual ProdutoModel ProdutoModel {get; set;}


    }
}