namespace API_Vendinha_InterFocus.Model
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string ClienteName { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public List<Divida> Dividas { get; set; }
    }
}
