namespace SAPCS.Models
{
    //0-CANCELADO, 1-FINALIZADO (retorno/confirmação), 2-PENDENTE (Se falta algum documento), 3-AGUARDANDO
    public enum EnumStatusCot : int
    {
        CANCELADO = 0,
        FINALIZADO = 1,
        PENDENTE = 2,
        AGUARDANDO = 3
    }
}