using System;
using System.Collections.Generic;
using System.IO;

namespace Totalizador
{
    public class CSV
    {
        private string _caminho { get; set; }
        public CSV(string caminho)
        {
            this._caminho = caminho;
        }

        public List<Registro> PegarRegistros()
        {
            List<Registro> registros = new();
            String[] linhas = File.ReadAllLines(this._caminho);

            int linhasVazias = 0;

            foreach (string linha in linhas)
            {
                String[] splitedLine = linha.Split(';');

                if (string.IsNullOrEmpty(splitedLine[0].Trim()) || string.IsNullOrEmpty(splitedLine[1].Trim()))
                {
                    linhasVazias++;
                    if (linhasVazias > 3)
                        break;
                    continue;
                }

                linhasVazias = 0;
                string[] linhaArr = linha.Split(';');
                Registro registro = new() 
                {
                    Cod = linhaArr[0],
                    Nome = linhaArr[1],
                    Cargo = linhaArr[2],
                    Local = linhaArr[3],
                    Quantidade = int.Parse(linhaArr[4]),
                    Valor = double.Parse(linhaArr[5])
                };
                registros.Add(registro);
            }
            return registros;
        }

        public void AppendLine(string line)
        {
            AppendLine(new string[] { line });
        }
        public void AppendLine(string[] lines)
        {
            File.AppendAllLines(this._caminho, lines);
        }
    }
}
