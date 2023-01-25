using System.Text.Json.Serialization;

namespace API_Vendinha_InterFocus.Model
{
    public class Divida
    {
        public Guid DividaId { get; set; }
        public decimal ValorDivida { get; set;}
        public bool EstaPaga { get; set;}
        public DateTime DataDeCriacao { get; set;}
        public DateTime DataDePagamento { get; set;}
        public Guid ClienteId { get; set;}
        [JsonIgnore]
        public Cliente? Cliente { get; set;}
    }
}
