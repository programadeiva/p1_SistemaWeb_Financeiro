using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
