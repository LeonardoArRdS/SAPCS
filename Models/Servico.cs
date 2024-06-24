using System.ComponentModel.DataAnnotations;

namespace SAPCS.Models
{
    public class Servico
    {
        #region Instância Propriedades
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeServ { get; set; }
        [Display(Name = "Seguradora")]
        public Seguradora Seguradora { get; set; }
        [Display(Name = "Selecione a seguradora")]
        public int SeguradoraId { get; set; }
        [Display(Name = "Status")]
        public bool StatusServ { get; set; }
        #endregion Instância Propriedades
    }
}