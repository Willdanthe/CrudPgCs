using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1_.Entity
{
    
    [Table("Usuario")] // Define o nome da tabela
    public class Usuario
    {
        [Column("id_usuario")] // Define explicitamente o nome da coluna
        public int Id_usuario { get; set; }
        
        [Column("nome")]
        public string Nome { get; set; } = string.Empty; // Valor padrão que evita o campo ser nullo

        [Column("email")]
        public string Email { get; set; } = string.Empty;
        
        
        
        
    }
}