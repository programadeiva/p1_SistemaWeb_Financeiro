using Microsoft.EntityFrameworkCore;

namespace SistemaWeb.Models
{
    public class Contexto: DbContext
    {

        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Classificacao> Classificacaos { get; set; }
        public DbSet<Conta> Contas { get; set; }


    }
}
