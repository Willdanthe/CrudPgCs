using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2.Atividade
{
    [Table("maquina",Schema = "cr")]
    public class Maquina
    {
        [Key]
        [Column("id_maquina")]
        public int Id_Maquina { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("velocidade")]
        public int Velocidade { get; set; }
        
        [Column("harddisk")]
        public int HardDisk { get; set; }

        [Column("placa_rede")]
        public int Placa_Rede{ get; set; }

        [Column("memoria_ram")]
        public int Memoria_Ram{ get; set; }

        [ForeignKey("usuarios")] // Fk de Usuario
        [Column("fk_usuario")]
        public int Fk_Usuario{ get; set; }

    }
}