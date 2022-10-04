namespace teste_payment_api.src.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public string ProdutosVendidos { get; set; }
        public EnumStatusVenda StatusVenda { get; set; }
        public DateTime Data { get; set; }
        
    }
}