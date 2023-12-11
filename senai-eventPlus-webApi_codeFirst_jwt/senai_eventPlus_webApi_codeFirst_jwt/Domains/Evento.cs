using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Evento.
    [Table("Evento")]
    //  Clase que representa a entidade Evento.
    public class Evento
    {
        //  Define a primary key
        [Key]
        //  Define o Auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idEvento { get; set; }

        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"id instituicao\" é obrigatório!")]
        public Guid idInstituicao { get; set; }

        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"id tipo evento\" é obrigatório!")]
        public Guid idTipoEvento { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"nome evento\" é obrigatório!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"Nome Evento\" deve conter entre 3 a 150 caracteres!")]
        public string nomeEvento { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "TEXT")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"descrição\" é obrigatório!")]     
        public string descricao { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "DATE")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"data do evento\" é obrigatório!")]        
        public DateTime dataEvento { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "TIME")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"hora do evento\" é obrigatório!")]
        //  Usado TimeSpan devido o EntityFrameWork não conseguir mapear com TimeOnly.
        public TimeSpan horarioEvento { get; set; }



        //  Define a ForeignKey
        [ForeignKey(nameof(idInstituicao))]
        public Instituicao? instituicao { get; set; }
        
        //  Define a ForeignKey
        [ForeignKey(nameof (idTipoEvento))]
        public TiposEvento? tipoEvento { get; set; }
    }
}
