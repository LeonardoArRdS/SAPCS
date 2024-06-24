using System;
using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class Cotacao
    {
        #region Instância Propriedades
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }
        [Display(Name = "Selecione o cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Funcionário")]
        public Funcionario Funcionario { get; set; }
        [Display(Name = "Selecione o funcionário")]
        public int FuncionarioId { get; set; }
        [Display(Name = "Serviço")]
        public Servico Servico { get; set; }
        [Display(Name = "Selecione o serviço")]
        public int ServicoId { get; set; }
        [Display(Name = "Status")]
        public EnumStatusCot StatusCot { get; set; }
        [Display(Name = "Data de criação")]
        public DateTime DtCriacao { get; set; }
        [Display(Name = "Data de modificação")]
        public DateTime DtModificacao { get; set; }
        #endregion Instância Propriedades
    }
}