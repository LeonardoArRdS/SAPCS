using System;
using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class Cliente
    {
        #region Instância Propriedades
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeCli { get; set; }
        [Display(Name = "Telefone")]
        public string TelCli { get; set; }
        [Display(Name = "Valor do telefone")]
        public EnumValTel ValTel { get; set; }
        [Display(Name = "CPF")]
        public string CPFCli { get; set; }
        [Display(Name = "Email")]
        public string EmailCli { get; set; }

        [Display(Name = "Valor do email")]
        public string ValEmail { get; set; }
        [Display(Name = "Data de nascimento")]
        public DateTime DtNascCli { get; set; }

        [Display(Name = "Status")]
        public bool StatusCli { get; set; } = true;

        [Display(Name = "Data de cadastro")]
        public DateTime DtCadastro { get; set; }

        [Display(Name = "Data de modificação")]
        public DateTime DtModificacao { get; set; }
        #endregion Instância Propriedades
    }
}