using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Usuário.
    [Table("Usuario")]
    //  Define que a propiedade email deve ser única
    [Index( nameof(email), IsUnique = true )]
    public class Usuario
    {
        //  Identificação da primary key
        [Key]
        //  Define o Auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idUsuario { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"nome\" é obrigatório!")]
        [StringLength(150,MinimumLength = 3, ErrorMessage = "O campo \"nome\" deve conter ente 3 e 150 caracteres!")]
        public string nome { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O campo \"email\" é obrigatório!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"email\" deve conter ente 3 e 150 caracteres!")]
        public string email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O campo \"senha\" é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"senha\" deve conter ente 3 e 100 caracteres!")]
        public string senha { get; set; }


        [Required(ErrorMessage = "É necessário informar o \"id tipo de usuário!\"!")]
        public Guid idTipoUsuario { get; set; }

        //  Define a chave estrangeira
        [ForeignKey("idTipoUsuario")]
        public TiposUsuario? tiposUsuario { get; set; }
    }
}
