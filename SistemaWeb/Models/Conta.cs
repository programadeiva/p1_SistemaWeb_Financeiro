using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public string Descricao { get; set; }
        public DateTime Pagamento { get; set; }
        public DateTime Vencimento { get; set; }
        public int Valor { get; set; }
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }
        public int ClassificacaoId { get; set; }
        public virtual Classificacao Classificacao { get; set; }

    }
}
