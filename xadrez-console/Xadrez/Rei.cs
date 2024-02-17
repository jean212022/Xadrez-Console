using System;
using Tabuleiro;

namespace Xadrez
{
    public class Rei : Peca
    {
        private PartidaDeXadrez PartidaDeXadrez;
        public Rei(Tabuleiros tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) { 
            this.PartidaDeXadrez = partida;
        }
        public override string ToString()
        {
            return "R";
        }
        private bool TesteTorreRoque(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.Peca(posicao);
            return peca != null && peca is Torre && peca.QuantMovimentos == 0 && peca.Cor == this.Cor;
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
            //Roque
            if(this.QuantMovimentos == 0 && !this.PartidaDeXadrez.Xeque)
            {
                //Roque Pequeno
                Posicao posTorre = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 3);
                if (this.TesteTorreRoque(posTorre))
                {
                    Posicao posicao1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    Posicao posicao2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 2);
                    if (this.Tabuleiro.Peca(posicao1) == null && this.Tabuleiro.Peca(posicao2) == null)
                    {
                        mat[posicao2.Linha, posicao2.Coluna] = true;
                    }
                }
                //Roque Grande
                Posicao posTorre2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 4);
                if (this.TesteTorreRoque(posTorre2))
                {
                    Posicao posicao1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    Posicao posicao2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 2);
                    Posicao posicao3 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 3);
                    if (this.Tabuleiro.Peca(posicao1) == null && this.Tabuleiro.Peca(posicao2) == null && this.Tabuleiro.Peca(posicao3) == null)
                    {
                        mat[posicao2.Linha, posicao2.Coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
