using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Gestao_Sock.Repositorys;
using API_Gestao_Sock.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sales_System_API.Model;

namespace Sales_System_API.Controllers
{
    [ApiController]
    [Route("api/vi/stocks")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository stockRepository;

        public StockController(IStockRepository stock){
            stockRepository = stock;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<StockModel>>> getAll(){
            return Ok(await stockRepository.GetAllStock()); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockModel>> getOne(int id){
         StockModel stockModel = await stockRepository.GetStockById(id);
         if(stockModel == null){
            return NotFound();
         } 
         return Ok(stockModel);
        }

        [HttpPost]
        public async Task<ActionResult<StockModel>> Salva([FromBody] StockModel stockModel){
          if(stockModel == null){
            return BadRequest();
          }  
          return Ok(await stockRepository.AddStock(stockModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id){
            bool apagou = await stockRepository.DeleteStockById(id);
            if(!apagou){
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StockModel>> atualiza([FromBody] StockModel stockModel, int id){
            if(stockRepository.GetStockById(id) == null){
                return NotFound();
            }
            return Ok(stockRepository.updateStockById(stockModel, id));
        }
    }
}