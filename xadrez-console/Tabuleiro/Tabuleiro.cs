using System;

namespace Tabuleiro
{
    public class Tabuleiros
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;
        public Tabuleiros(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            this.Pecas = new Peca[this.Linhas, this.Colunas];
        }
        public Peca Peca(int linha, int coluna)
        {
            return this.Pecas[linha, coluna];
        }
        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            this.Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
    }
}
