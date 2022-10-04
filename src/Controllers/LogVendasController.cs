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
        public IActionResult AdicionarVenda(Vendedor venda){

            var produtos = venda.Vendas[0].ProdutosVendidos;

            if(produtos == ""){
                Console.WriteLine("Deve ser inserido ao menos um produto na venda");
                return NotFound();
            }
            
            _context.Add(venda);
            _context.SaveChanges();

            return Ok(venda);

        }

        [HttpGet("ObterVenda/{id}")]
        public IActionResult ObterVendaPorId(int id){

            var vendaBanco = _context.Vendas.Find(id);

            if(vendaBanco == null){
                return NotFound();
            }

            return Ok(vendaBanco);

        }

        [HttpPut("AtualizarStatus/{id}")]
        public IActionResult Atualizar(int id, Venda codigoStatusVenda){

            var vendaBanco = _context.Vendas.Find(id);
            
            if (vendaBanco == null){

                return NotFound();

            }

            switch (vendaBanco.StatusVenda)
            {
                case (EnumStatusVenda)0:
                    vendaBanco.StatusVenda = (EnumStatusVenda)codigoStatusVenda.StatusVenda;
                    if(vendaBanco.StatusVenda == (EnumStatusVenda)1 || vendaBanco.StatusVenda == (EnumStatusVenda)4){
                        _context.Vendas.Update(vendaBanco);
                        _context.SaveChanges();
                        return Ok(vendaBanco);
                    } else {
                        return NotFound();
                    }

                case (EnumStatusVenda)1:
                    vendaBanco.StatusVenda = (EnumStatusVenda)codigoStatusVenda.StatusVenda;
                    if(vendaBanco.StatusVenda == (EnumStatusVenda)2 || vendaBanco.StatusVenda == (EnumStatusVenda)4){
                        _context.Vendas.Update(vendaBanco);
                        _context.SaveChanges();
                        return Ok(vendaBanco);
                    } else {
                        return NotFound();
                    }

                case (EnumStatusVenda)2:
                        vendaBanco.StatusVenda = (EnumStatusVenda)3;
                        _context.Vendas.Update(vendaBanco);
                        _context.SaveChanges();
                        return Ok(vendaBanco);

                default:
                    return NotFound();
            }

        }
    }
}