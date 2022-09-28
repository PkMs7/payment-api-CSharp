namespace teste_payment_api.src.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Vendedor DadosVendedor { get; set; }
        public DateTime Data { get; set; }
        public string ProdutosVendidos { get; set; }
        public EnumStatusVenda StatusVenda { get; set; }
        
    }
}