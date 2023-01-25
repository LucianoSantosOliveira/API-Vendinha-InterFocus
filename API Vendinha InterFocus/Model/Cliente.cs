using System.Text.Json.Serialization;

namespace API_Vendinha_InterFocus.Model
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string ClienteName { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<Divida>? Dividas { get; set; }
    }
}
