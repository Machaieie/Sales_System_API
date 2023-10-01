using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_System_API.Model
{
    public class MovimentosStockModel
    {
        public int Id{get; set;}
        public int StockId{get; set;}
        public int Quantidade {get; set;}
        public DateTime Data {get; set;}

        [ForeignKey("StockId")]
        public virtual StockModel StockModel {get; set;}
    }
}