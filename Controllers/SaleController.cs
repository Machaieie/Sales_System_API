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
    [Route("api/vi/vendas")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository saleRepository;

        public SaleController(ISaleRepository saleRepository){
            this.saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VendaModel>>> getAll(){
            List<VendaModel> vendaModels = await saleRepository.GetAllSales();
            return Ok(vendaModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaModel>> getOne(int id){
          VendaModel venda = await saleRepository.GetSaleById(id);
          if(venda == null){
            return NotFound();
          }
          return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult<VendaModel>> Salva([FromBody] VendaModel vendaModel){
            if(vendaModel == null){
                return BadRequest();
            }

            return Ok(await saleRepository.AddSale(vendaModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id){
            bool apagou = await saleRepository.DeleteSaleById(id);
            if(!apagou){
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VendaModel>> updateVenda([FromBody] VendaModel vendaModel, int id){
           if(saleRepository.GetSaleById(id) == null){
            return BadRequest();
           }
            return Ok(await saleRepository.updateSaleById(vendaModel, id));
        }
    }
}