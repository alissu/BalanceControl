using Infrastructure.Model;

namespace WebAPI.Models
{
    public class MovResumo : BaseModel
    {
        public enum ETipo : byte
        {
            Entrada = 11,
            Saida = 12,
            SaldoInicial = 21,
            SaldoFinal = 22
        }

        public DateTime DataMovimento { get; private set; }
        public ETipo Tipo { get; private set; }
        public decimal Valor { get; private set; }

        public void UpdateValor(decimal valor)
        {
            Valor = valor;
        }
    }
}
