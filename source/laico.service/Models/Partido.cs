using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laico.service.Models
{
    [Table("partido", Schema ="laico")]
    public class Partido
    {
        #region Constructor
        public Partido()
        {

        }
        #endregion


        #region Properties
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Sigla
        {
            get;
            set;
        }

        [Required]
        public string Nome
        {
            get;
            set;
        }

        public ICollection<Candidato> Candidatos
        {
            get;
            set;
        }
        #endregion
    }
}
