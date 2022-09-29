using Microsoft.AspNetCore.Mvc;
using teste_payment_api.src.Context;
using teste_payment_api.src.Models;

namespace teste_payment_api.src.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class LogVendas : ControllerBase
    {
        private readonly TesteVendasContext _context;

        public LogVendas(TesteVendasContext context){

            _context = context;

        }

        [HttpPost("CadastrarVenda")]
        public IActionResult AdicionarVenda(Venda venda){

            
            _context.Add(venda);
            _context.SaveChanges();

            return Ok(venda);
        }

        [HttpGet("ObterVenda/{id}")]
        public IActionResult ObterVendaPorId(int id){

            var vendaBanco = _context.Vendas.Find(id);

            return Ok(vendaBanco);
        }

        [HttpPut("AtualizarStatus/{StatusVenda}")]
        public IActionResult Atualizar(int id, EnumStatusVenda statusVenda){

            var vendaBanco = _context.Vendas.Find(id);
            
            if (vendaBanco == null){

                return NotFound();

            }

            vendaBanco.StatusVenda = statusVenda;

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();


            return Ok(vendaBanco);

        }
    }
}