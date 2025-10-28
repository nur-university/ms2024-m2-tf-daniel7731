using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanesRecetas.infraestructure.Persistence.DomainModel.Config
{
    public class TiempoPersistenceModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }
    }
}
