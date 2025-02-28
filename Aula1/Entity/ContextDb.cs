using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aula1_.Entity
{
    public class ContextDb : DbContext
    {
        public DbSet<Usuario> Usuarios {get;set;} // Aqui a gente define a tabela que a gente vai usar, o DbSet é uma coleção de objetos que a gente vai usar. A gente vai tratar como se fosse uma tabela, mas essa é uma coleção de objetos ou uma lista de objetos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Aula1;Port=5432;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario"); // Aqui a gente mapeia a tabela usuários
            // Chave primária para id no user
            
        } // Aqui a gente está garantindo que a lista usuário vai ser usada para a tabela usuário no banco de dados
    }
}