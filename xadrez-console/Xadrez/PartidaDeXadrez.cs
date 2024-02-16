using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    public class PartidaDeXadrez
    {
        public Tabuleiros Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas, Capturadas;
        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiros(8, 8);
            this.JogadorAtual = Cor.Branco;
            this.Terminada = false;
            this.Turno = 1;
            this.Pecas = new HashSet<Peca>();
            this.Capturadas = new HashSet<Peca>();
            this.ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = this.Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMov();
            Peca pecaCap = this.Tabuleiro.RetirarPeca(destino);
            this.Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCap != null)
            {
                Capturadas.Add(pecaCap);
            }
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca peca in Capturadas)
            {
                if(peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if(this.Tabuleiro.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posicao escolhida!");
            }
            if(this.JogadorAtual != this.Tabuleiro.Peca(origem).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!this.Tabuleiro.Peca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para realizar com a peça escolhida!");
            }
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invalida!");
            }
        }
        private void MudaJogador()
        {
            if (this.JogadorAtual == Cor.Branco)
            {
                this.JogadorAtual = Cor.Preto;
            } else
            {
                this.JogadorAtual = Cor.Branco;
            }
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            this.Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna,linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branco));

            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preto));
        }
    }
}
