using System;
using Tabuleiro;

namespace Xadrez
{
    public class Rainha : Peca
    {
        public Rainha(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "Q";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            // Acima
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Linha--;
            }
            // Abaixo
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Linha++;
            }
            // Direita
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Coluna++;
            }
            // Esquerda
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.Coluna--;
            }
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
