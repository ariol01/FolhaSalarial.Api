namespace Folha.Models
{
    public abstract class Pessoa
    {
        protected Pessoa()
        {
            
        }
        public Pessoa(string nome, string sobrenome, string documento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
        }
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }

    }
}
