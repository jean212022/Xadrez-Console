using System;
using xadrez_console.Tabuleiro;

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
        public Peca Peca(Posicao posicao)
        {
            return this.Pecas[posicao.Linha, posicao.Coluna];
        }
        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (this.ExistePeca(posicao))
            {
                throw new TabuleiroException("Já exite uma peça nessa posição!");
            }
            this.Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
        public bool PosicaoValida(Posicao posicao)
        {
            if(posicao.Linha < 0 || posicao.Linha >= this.Linhas)
            {
                return false;
            }
            if (posicao.Coluna < 0 || posicao.Coluna >= this.Colunas)
            {
                return false;
            }
            return true;
        }
        public bool ExistePeca(Posicao posicao)
        {
            this.ValidarPosicao(posicao);
            return this.Pecas[posicao.Linha, posicao.Coluna] != null;
        }
        public void ValidarPosicao(Posicao posicao)
        {
            if (!this.PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
