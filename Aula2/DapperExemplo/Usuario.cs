using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aula2
{
    // Vamos usar o atributo de mapeamento c# para mapear os campos da table a de usuários para a tabela usuário
    [Table("usuario")]
    public class Usuario
    {
        // Se for chave estrangeira, usar [ForeignKey("Nome_da_coluna")]
         // Atributo de mapemento de chave primária
        [Column("id_usuario")]
        public int Id_usuario { get; set; }
        [Key]
        
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;
        
        
        
        
        
        
    }
}