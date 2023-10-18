using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Gestao_Sock.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Sales_System_API.Model;

namespace Sales_System_API.Controllers
{
    [ApiController]
    [Route("api/vi/controller")]
    public class MovimentsController : ControllerBase
    {
        private readonly MovimentsRepository movimentsRepository;

        public MovimentsController(MovimentsRepository moviments){
            movimentsRepository = moviments;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovimentosStockModel>>> getAll(){
            return Ok(await movimentsRepository.GetAllMovimentStock());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimentosStockModel>> getOn(int id){
        MovimentosStockModel movimento = await movimentsRepository.GetMovimentStockById(id);
        if(movimento == null){
            return NotFound();
        }
        return Ok(movimento);
        }
    }
}