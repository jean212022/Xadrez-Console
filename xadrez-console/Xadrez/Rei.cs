using System;
using Tabuleiro;

namespace Xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "R";
        }
        private bool PodeMover(Posicao posicao)
        {
            return this.Tabuleiro.Peca(posicao) == null || this.Tabuleiro.Peca(posicao).Cor != this.Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas,Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0,0);

            // Acima
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Abaixo
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Nordeste
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Sudeste
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Direita
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Esquerda
            posicao.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Noroeste
            posicao.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //Sudoeste
            posicao.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            return mat;
        }
    }
}
