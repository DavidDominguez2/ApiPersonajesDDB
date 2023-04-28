using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPersonajesDDB.Models {
    [Table("PERSONAJEs")]
    public class Personaje {

        [Key]
        [Column("IDPERSONAJE")]
        public int IdPesonaje { get; set; }

        [Column("PERSONAJE")]
        public string Nombre { get; set; }

        [Column("IMAGEN")]
        public string Imagen { get; set; }

        [Column("IDSERIE")]
        public int IdSerie { get; set; }
    }
}
