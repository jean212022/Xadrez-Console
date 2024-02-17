using System;
using Tabuleiro;

namespace Xadrez
{
    public class Piao : Peca
    {
        private PartidaDeXadrez PartidaDeXadrez;
        public Piao(Tabuleiros tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.PartidaDeXadrez = partida;
        }
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
                if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao) && this.Tabuleiro.Peca(posicao) == null)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima
                posicao.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna);
                if (this.QuantMovimentos == 0 && this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao) && this.Tabuleiro.Peca(posicao) == null)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima Esquerda
                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima Direita
                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                //En Passant
                if (this.Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (this.Tabuleiro.PosicaoValida(esquerda) && this.Tabuleiro.Peca(esquerda) != null && this.Tabuleiro.Peca(esquerda).Cor != this.Cor && this.Tabuleiro.Peca(esquerda) == this.PartidaDeXadrez.PecaVuneralvelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (this.Tabuleiro.PosicaoValida(direita) && this.Tabuleiro.Peca(direita) != null && this.Tabuleiro.Peca(direita).Cor != this.Cor && this.Tabuleiro.Peca(direita) == this.PartidaDeXadrez.PecaVuneralvelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            } else
            {
                // Acima
                posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao) && this.Tabuleiro.Peca(posicao) == null)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima
                posicao.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna);
                if (this.QuantMovimentos == 0 && this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao) && this.Tabuleiro.Peca(posicao) == null)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima Direita
                posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                // Mais Acima Esquerda
                posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.PosicaoValida(posicao) && this.Tabuleiro.Peca(posicao) != null && this.Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                //En Passant
                if (this.Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (this.Tabuleiro.PosicaoValida(esquerda) && this.Tabuleiro.Peca(esquerda) != null && this.Tabuleiro.Peca(esquerda).Cor != this.Cor && this.Tabuleiro.Peca(esquerda) == this.PartidaDeXadrez.PecaVuneralvelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (this.Tabuleiro.PosicaoValida(direita) && this.Tabuleiro.Peca(direita) != null && this.Tabuleiro.Peca(direita).Cor != this.Cor && this.Tabuleiro.Peca(direita) == this.PartidaDeXadrez.PecaVuneralvelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
