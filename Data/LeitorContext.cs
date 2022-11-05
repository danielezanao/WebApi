using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Model;

namespace webapi.Data
{
    public class LeitorContext : DbContext
    {
        public LeitorContext(DbContextOptions<LeitorContext> options) : base(options)
        {
        }
        //aqui criou a primeira tabela no banco
        public DbSet<Leitor> Leitores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var leitor = modelBuilder.Entity<Leitor>();
            leitor.ToTable("tb_leitor");
            leitor.HasKey(x => x.Id);
            leitor.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            leitor.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            leitor.Property(x => x.Email).HasColumnName("email");
            leitor.Property(x => x.DataNascimento).HasColumnName("datanascimento");

            var livro = modelBuilder.Entity<Livro>();
            livro.ToTable("tb_livro");
            livro.HasKey(x => x.Id);
            livro.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            livro.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            livro.Property(x => x.Autor).HasColumnName("autor");
            livro.Property(x => x.Genero).HasColumnName("genero");
            livro.Property(x => x.Ano).HasColumnName("ano");

            var emprestimo = modelBuilder.Entity<Emprestimo>();
            emprestimo.ToTable("tb_emprestimo");
            emprestimo.HasKey(x => x.Id);
            emprestimo.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            emprestimo.Property(x => x.Id_leitor).HasColumnName("id_leitor");
            emprestimo.Property(x => x.Id_livro).HasColumnName("id_livro");
            emprestimo.Property(x => x.DataEmprestimo).HasColumnName("data_emprestimo");
            emprestimo.Property(x => x.DataDevolucao).HasColumnName("data_devolucao");
        }
    }
}