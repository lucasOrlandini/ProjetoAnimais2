using Fatec.ProjetoAnimais.DB.Entitidades;
using MySql.Data.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Fatec.ProjetoAnimais.DB.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AutismoContext : DbContext
    {
        public AutismoContext()
           : base("name= AutismoConexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Autismo");

            //Atividade
            modelBuilder.Entity<Atividade>().ToTable("Atividade");
            //modelBuilder.Entity<Atividade>().HasKey(c => c.id);
            //modelBuilder.Entity<Atividade>().Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Atividade>().Property(c => c.nomeAtividade).HasMaxLength(255);
            //modelBuilder.Entity<Atividade>().Property(c => c.descricaoAtividade).HasMaxLength(255);
            //modelBuilder.Entity<Atividade>().Property(c => c.aluno).HasMaxLength(255);
            //modelBuilder.Entity<Atividade>().Property(c => c.dataEntrega);


            //Pessoa
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            //modelBuilder.Entity<Pessoa>().HasKey(c => c.id);
            //modelBuilder.Entity<Pessoa>().Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Pessoa>().Property(c => c.cpf).HasMaxLength(255);
            //modelBuilder.Entity<Pessoa>().Property(c => c.email).HasMaxLength(255);
            //modelBuilder.Entity<Pessoa>().Property(c => c.nome).HasMaxLength(255);
            //modelBuilder.Entity<Pessoa>().Property(c => c.sobrenome).HasMaxLength(255);
            //modelBuilder.Entity<Pessoa>().Property(c => c.datanasc);
            //modelBuilder.Entity<Pessoa>().Property(c => c.senha).HasMaxLength(255);
            //modelBuilder.Entity<Pessoa>().Property(c => c.perfil);

            modelBuilder.Entity<Perfil>().ToTable("Perfil");

            modelBuilder.Entity<TipoAtividade>().ToTable("TipoAtividade");
        }

        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        public virtual DbSet<Perfil> Perfil { get; set; }

        public virtual DbSet<TipoAtividade> TipoAtividade { get; set; }


    }
}
