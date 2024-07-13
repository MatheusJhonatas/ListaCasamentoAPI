using System;
namespace Models.Pessoa
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public DateTime Aniversario { get; set; }
        public Guid Id { get; set; }
        public string Sexo { get; set; }
        public string Familia { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}