using System;
using System.Collections.Generic;
using System.IO;

namespace Totalizador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o caminho do arquivo CSV");
            string caminho = Console.ReadLine();
            Console.Clear();

            if (File.Exists(caminho))
            {
                CSV csv = new CSV(caminho);
                List<Registro> registros = csv.PegarRegistros();
                List<Relatorio> relatorioFinal = Relatorio.Gerar(registros);
                foreach (Relatorio relatorio in relatorioFinal)
                {
                    Console.WriteLine($"{relatorio.Cargo.PadRight(15, '.')} total_vendido:{relatorio.Valor.ToString("0.##").PadLeft(15, '.')} quantidade:{relatorio.Quantidade.ToString().PadLeft(15, '.')}");
                }

            }
            else
            {
                Console.WriteLine("Arquivo não encontrado");
            }
        }
    }
}
