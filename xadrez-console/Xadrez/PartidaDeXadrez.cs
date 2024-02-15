using System;
using Tabuleiro;

namespace Xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiros Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }
        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiros(8, 8);
            this.JogadorAtual = Cor.Branco;
            this.Terminada = false;
            this.Turno = 1;
            this.ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = this.Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMov();
            Peca pecaCap = this.Tabuleiro.RetirarPeca(destino);
            this.Tabuleiro.ColocarPeca(peca, destino);
        }
        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('e', 7).ToPosicao());
        }
    }
}
