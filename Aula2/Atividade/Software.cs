using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2.Atividade
{
    [Table("cr.software", Schema = "cr")]
    public class Software
    {
        [Key]
        [Column("id_software")]
        public int Id_software { get; set; }
        
        [Column("produto")]
        public string Produto{ get; set; } = string.Empty;

        [Column("harddisk")]
        public int HardDisk { get; set; }

        [Column("memoria_ram")]
        public int Memoria_Ram { get; set; }

        [ForeignKey("maquina")]
        [Column("fk_maquina")]
        public int Fk_Maquina { get; set; }
        
    }
}