using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Presença Evento
    [Table("PresencasEvento")]
    //  Clase que representa a entidade Presença Evento.
    public class PresencasEvento
    {
        //  Define a primary key
        [Key]
        //  Define o Auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idPresencasEvento { get; set; }

        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"id presenca evento\" é obrigatório!")]
        public Guid idUsuario { get; set; }

        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"id evento\" é obrigatório!")]
        public Guid idEvento { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "BIT")]
        //  Define um valor padrão
        [DefaultValue(0)]
        public bool situacao { get; set; }

        //  Define a ForeignKey
        [ForeignKey(nameof(idUsuario))]
        public Usuario? usuario { get; set; }

        //  Define a ForeignKey
        [ForeignKey(nameof(idEvento))]
        public Evento? evento { get; set;}
    }
}
