using System;
using Tabuleiro;

namespace Xadrez
{
    public class Piao : Peca
    {
        public Piao(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "P";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);
            if (this.Cor == Cor.Branco)
            {
                // Acima
                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima
                posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao) && this.QuantMovimentos == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
            } else
            {
                // Acima
                posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima
                posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao) && this.QuantMovimentos == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
            }
            return mat;
        }
    }
}
