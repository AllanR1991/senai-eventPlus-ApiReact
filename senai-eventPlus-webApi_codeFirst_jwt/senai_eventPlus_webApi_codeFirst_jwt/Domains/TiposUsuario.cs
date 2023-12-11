using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Instituição.
    [Table("TipoUsuario")]
    //  Define que a propriedade tipoUsuarui deve ser única
    [Index(nameof(tipoUsuario), IsUnique = true)]
    public class TiposUsuario
    {
        //  Definindo que idTipoUsuario é a Chave Primaria.
        [Key]
        //  Gera o auto incremento.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idTipoUsuario { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(100)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O \"Tipo de Usúario\" é obrigatório o preenchimento!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(100,MinimumLength = 3, ErrorMessage = "Necessário o campo \"Tipo Usúario\" ter entre 3 e 100 caracteres!")]
        public string tipoUsuario { get; set; }
    }
}
