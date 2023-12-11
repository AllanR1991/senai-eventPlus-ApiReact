using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_eventPlus_webApi_codeFirst_jwt.Domains
{
    //  Define a criação da tabela Instituição.
    [Table("Instituicao")]
    //  Define que a propriedade CNPJ deve ser única
    [Index(nameof(cnpj), IsUnique = true)]
    public class Instituicao
    {
        //  Identificação da primary key
        [Key]
        //  Define o Auto incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idInstituicao { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(14)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"cnpj\" é obrigatório!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(14,MinimumLength = 14, ErrorMessage = "O campo \"cnpj\" deve conter os 14 digitos sem exeções!")]
        public string cnpj { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"endereço\" é obrigatório!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(150,MinimumLength = 3, ErrorMessage = "O campo \"endereço\" deve conter entre 3 e 150 caracteres!")]
        public string endereco { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"razão social\" é obrigatório!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"razão social\" deve conter entre 3 e 150 caracteres!")]
        public string razaoSocial { get; set; }

        //  Define o tipo da coluna
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que variável é obrigatória.
        [Required(ErrorMessage = "O campo \"nome fantasia\" é obrigatório!")]
        //  Define que a variável deve ter um comprimento máximo e mínimo.
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"nome fantasia\" deve conter entre 3 e 150 caracteres!")]
        public string nomeFantasia { get; set; }
    }
}
