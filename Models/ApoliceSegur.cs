using System;
using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class ApoliceSegur
    {
        #region Instância Propriedades
        public int Id { get; set; }
        [Display(Name = "Nome do arquivo")]
        public string NomeArquivo { get; set; }
        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }
        [Display(Name = "Selecione o cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Funcionário")]
        public Funcionario Funcionario { get; set; }
        [Display(Name = "Selecione o funcionário")]
        public int FuncionarioId { get; set; }
        #endregion Instância Propriedades
    }
}