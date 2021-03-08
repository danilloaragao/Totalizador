using System.Collections.Generic;
using System.Linq;

namespace Totalizador
{
    public class Relatorio
    {
        public string Cargo { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }

        public static List<Relatorio> Gerar(List<Registro> registros)
        {
            List<Relatorio> relatorioFinal = new();
            List<string> cargos = registros.Select(r => r.Cargo).Distinct().ToList();

            foreach (string cargo in cargos)
            {
                List<Registro> registrosFiltrados = registros.Where(r => r.Cargo.Equals(cargo)).ToList();
                Relatorio relatorioParcial = new();
                relatorioParcial.Cargo = cargo;
                relatorioParcial.Quantidade = registrosFiltrados.Aggregate(0, (total, atual) => total += atual.Quantidade, soma => soma);
                relatorioParcial.Valor = registrosFiltrados.Aggregate(0, (double total, Registro atual) => total += atual.Valor, soma => soma);

                relatorioFinal.Add(relatorioParcial);
            }
            return relatorioFinal.OrderBy(r => r.Cargo).ToList();

        }
    }
}
