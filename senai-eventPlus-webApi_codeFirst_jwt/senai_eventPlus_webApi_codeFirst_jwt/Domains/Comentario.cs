using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Comentário.
    [Table("Comentario")]
    //  Clase que representa a entidade Comentário.
    public class Comentario
    {
        //  Define a identificação da primary key
        [Key]
        //  Define o Auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idComentario { get; set; }

        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"id usuario\" é obrigatório!")]
        public Guid idUsuario { get; set; }

        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"id evento\" é obrigatório!")]
        public Guid idEvento { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "TEXT")]
        // Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"descrição\" é obrigatório!")]
        public string descricao { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "BIT")]
        //  Define um valor padrão
        [DefaultValue(0)]
        public bool exibe { get; set; }

        //  Define a ForeignKey
        [ForeignKey(nameof(idUsuario))]
        public Usuario? usuario { get; set; }

        //  Define a ForeignKey
        [ForeignKey(nameof(idEvento))]
        public Evento? evento { get; set; }

    }
}
