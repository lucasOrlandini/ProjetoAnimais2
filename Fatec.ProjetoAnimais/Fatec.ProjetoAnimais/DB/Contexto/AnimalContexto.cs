﻿using Fatec.ProjetoAnimais.DB.Entitidades;
using MySql.Data.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Fatec.ProjetoAnimais.DB.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AnimalContexto : DbContext
    {
        public AnimalContexto()
           : base("name=AnimalConexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("animais");

            //Animal
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Animal>().HasKey(c => c.id);
            modelBuilder.Entity<Animal>().Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Animal>().Property(c => c.cidade_encontrado).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.condicoes).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.especie).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.porte).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.raca).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.sexo).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.vacinas).HasMaxLength(255);
            modelBuilder.Entity<Animal>().Property(c => c.situacao).HasMaxLength(55);

            //Pessoa
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Pessoa>().HasKey(c => c.id);
            modelBuilder.Entity<Pessoa>().Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Pessoa>().Property(c => c.cpf).HasMaxLength(255);
            modelBuilder.Entity<Pessoa>().Property(c => c.email).HasMaxLength(255);
            modelBuilder.Entity<Pessoa>().Property(c => c.nome).HasMaxLength(255);
            modelBuilder.Entity<Pessoa>().Property(c => c.sobrenome).HasMaxLength(255);
            modelBuilder.Entity<Pessoa>().Property(c => c.datanasc);
            modelBuilder.Entity<Pessoa>().Property(c => c.senha).HasMaxLength(255);
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
    }
}
