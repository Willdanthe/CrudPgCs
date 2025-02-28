using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aula2.Atividade
{
    [Table("cr.usuarios",Schema = "cr")]
    public class Usuarios
    {
        [Key]
        [Column("id_usuario")]
        public int Id_usuario { get; set; }

        [Column("nome_usuario")]
        public string Nome_Usuario { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("especialidade")]
        public string Especialidade { get; set; } = string.Empty;

        [Column("ramal")]
        public int Ramal { get; set; }         
    }
}