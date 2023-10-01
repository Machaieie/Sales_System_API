using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_System_API.Model
{
    public class ProdutoModel
    {

        
        public int Id { get; set; }
        public string? Nome {get; set;}

        public string? Descricao {get; set;}

        public int Categoria {get;set;} 
        
    }
}