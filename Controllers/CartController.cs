using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Gestao_Sock.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Sales_System_API.Model;

namespace Sales_System_API.Controllers
{
    [Route("api/v1/carinho")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository cartRepository;

        public CartController(CartRepository cartRepository){
            this.cartRepository = cartRepository;
        }
  
       [HttpGet]
       public async Task<ActionResult<List<CarinhoModel>>> buscarTodos(){
         return Ok(await cartRepository.GetAllCarts());
       }

       [HttpGet("{/id}")]
       public async Task<ActionResult<CarinhoModel>> getOn(string id){
        CarinhoModel carinho = await cartRepository.GetCartById(id);
        
       }


    }
}