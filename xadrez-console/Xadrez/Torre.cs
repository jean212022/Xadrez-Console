using System;
using Tabuleiro;

namespace Xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "T";
        }
        private bool PodeMover(Posicao posicao)
        {
            return (this.Tabuleiro.Peca(posicao) == null || this.Tabuleiro.Peca(posicao).Cor != this.Cor);
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
            return mat;
        }
    }
}
