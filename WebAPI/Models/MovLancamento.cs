using Infrastructure.Model;

namespace WebAPI.Models
{
    public class MovLancamento : BaseModel
    {
        public enum ETipo : byte
        {
            Entrada = 11,
            Saida = 12
        }

        public DateTime DataMovimento { get; set; }
        public ETipo Tipo { get; set; }
        public decimal Valor { get; set; }

        public void UpdateData(DateTime dataMovimento)
        {
            DataMovimento = dataMovimento;
        }

        public void UpdateTipo(ETipo tipo)
        {
            Tipo = tipo;
        }

        public void UpdateValor(decimal valor)
        {
            Valor = valor;
        }
    }
}
