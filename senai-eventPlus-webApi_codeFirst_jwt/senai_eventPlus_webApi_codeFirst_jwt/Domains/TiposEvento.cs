using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Tipo Evento.
    [Table("TiposEvento")]
    //  Define que a classe CNPJ deve ser única.
    [Index(nameof(tipoEvento), IsUnique = true )]
    public class TiposEvento
    {
        //  Identificação da primary key
        [Key]
        //  Define o Auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idTiposEvento { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(100)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"tipo evento\" é obrigatório!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"tipo evento\" deve conter entre 3 e 100 caracteres!")]
        public string tipoEvento { get; set; }
    }
}
