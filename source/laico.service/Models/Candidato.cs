using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laico.service.Models
{
    [Table("candidato", Schema = "laico")]
    public class Candidato
    {
        public Candidato()
        {
        }

        public int Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome
        {
            get;
            set;
        }

        public string Documento
        {
            get;
            set;
        }

        [DisplayName("Partido")]
        public int PartidoId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "O campo Partido é obrigatório.")]
        public virtual Partido Partido
        {
            get;
            set;
        }
    }
}
