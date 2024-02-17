using System;
using Tabuleiro;

namespace Xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "B";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            // Nordeste
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Linha--;
                posicao.Coluna--;
            }
            //Sudoeste
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Linha++;
                posicao.Coluna++;
            }
            //Sudeste
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Linha--;
                posicao.Coluna++;
            }
            //Noroeste
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Linha++;
                posicao.Coluna--;
            }
            return mat;
        }
    }
}
