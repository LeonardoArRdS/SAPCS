using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class Usuario
    {
        #region Instância Propriedades
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public Funcionario Funcionario { get; set; }
        [Display(Name = "Selecione o funcionário")]
        public int FuncionarioId { get; set; }

        public string Email { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }
        public DateTime UltimoAcesso { get; set; }
        #endregion Instância Propriedades
    }
}