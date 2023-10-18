using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Gestao_Sock.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace Sales_System_API.Controllers
{
    [ApiController]
    [Route("api/vi/stocks")]
    public class StockController : ControllerBase
    {
        private readonly StockRepository stockRepository;

        public StockController(StockRepository stock){
            stockRepository = stock;
        }
        
        
    }
}