using System;
using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class Funcionario
    {
        #region Instância Propriedades

        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeFunc { get; set; }
        [Display(Name = "Telefone")]
        public string TelFunc { get; set; }

        public virtual Usuario Usuario { get; set; }
        #endregion Instância Propriedades
    }
}