using System;
using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class Seguradora
    {
        #region Instância Propriedades
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeSegur { get; set; }
        [Display(Name = "Endereço")]
        public string EndSegur { get; set; }
        [Display(Name = "Telefone de contato")]
        public string TelSegur { get; set; }
        [Display(Name = "Site")]
        public string SiteSegur { get; set; }
        [Display(Name = "Nome de contato")]
        public string NomeContSegur { get; set; }
        [Display(Name = "Email de contato")]
        public string EmailContSegur { get; set; }
        [Display(Name = "Status")]
        public bool StatusSegur { get; set; }
        #endregion Instância Propriedades
    }
}