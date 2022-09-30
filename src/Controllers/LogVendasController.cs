using Microsoft.AspNetCore.Mvc;
using teste_payment_api.src.Context;
using teste_payment_api.src.Models;
using System.Text.Json;

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

                // Status 0 = AguardandoPagamento conforme classe EnumStatusVenda
                if (venda.StatusVenda == 0){

                    _context.Add(venda);
                    _context.SaveChanges();

                    return Ok(venda);

                } else {
                    
                    Console.WriteLine($"O status da venda só pode ser 'Aguardando Pagamento' (code: 0)");
                    return NotFound();

                }

        }

        [HttpGet("ObterVenda/{id}")]
        public IActionResult ObterVendaPorId(int id){

            var vendaBanco = _context.Vendas.Find(id);

            return Ok(vendaBanco);
        }

        [HttpPut("AtualizarStatus/{StatusVenda}")]
        public IActionResult Atualizar(int id, Venda venda){

            var vendaBanco = _context.Vendas.Find(id);
            
            if (vendaBanco == null){

                return NotFound();

            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();


            return Ok(vendaBanco);

        }
    }
}