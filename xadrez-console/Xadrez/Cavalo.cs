using System;
using Tabuleiro;

namespace Xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "C";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            // Mais Acima Esquerda
            posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais Acima Direita
            posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais Abaixo Esquerda
            posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais Abaixo Direita
            posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais para Esquerda Acima
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais para Direita Acima
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais para Esquerda Abaixo
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // Mais para Direita Abaixo
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 2);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            return mat;
        }
    }
}
