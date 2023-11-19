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
    [Route("api/v1/carinho")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository cartRepository){
            this.cartRepository = cartRepository;
        }
  
       [HttpGet]
       public async Task<ActionResult<List<CarinhoModel>>> buscarTodos(){
         return Ok(await cartRepository.GetAllCarts());
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<CarinhoModel>> getOn(int id){
        CarinhoModel carinho = await cartRepository.GetCartById(id);
       if(carinho == null){
        return NotFound();
       }
       return Ok(carinho);
       }

       [HttpPost]
       public async Task<ActionResult<CarinhoModel>> salvarCarinho([FromBody] CarinhoDTO carinho){
        if(carinho == null){
            return BadRequest();
        }
        CarinhoModel model = await cartRepository.AddCart(carinho);
        return Ok(model);
       }


       [HttpDelete("{id}")]
       public async Task<ActionResult> delete(int id){
            bool apagou = await cartRepository.DeleteCartById(id);
            if(!apagou){
                return BadRequest();
            }
                return Ok();
       }

       [HttpPut("{id}")]
       public async Task<ActionResult<CarinhoModel>> updateCarinho([FromBody] CarinhoModel carinho, int id){
            CarinhoModel carinhoModel = await cartRepository.UpdateCartById(carinho, id);
            return Ok(carinhoModel);
       }

    }
}