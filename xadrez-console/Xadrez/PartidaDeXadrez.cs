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
        public bool Xeque { get; private set; }
        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiros(8, 8);
            this.JogadorAtual = Cor.Branco;
            this.Terminada = false;
            this.Turno = 1;
            this.Pecas = new HashSet<Peca>();
            this.Capturadas = new HashSet<Peca>();
            this.Xeque = false;
            this.ColocarPecas();
        }
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = this.Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMov();
            Peca pecaCap = this.Tabuleiro.RetirarPeca(destino);
            this.Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCap != null)
            {
                Capturadas.Add(pecaCap);
            }
            // Roque Pequeno
            if(peca is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao posicaoTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao posicaoTorreDestino = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torre = this.Tabuleiro.RetirarPeca(posicaoTorre);
                torre.IncrementarQuantidadeMov();
                this.Tabuleiro.ColocarPeca(torre, posicaoTorreDestino);
            }
            // Roque Grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao posicaoTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao posicaoTorreDestino = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torre = this.Tabuleiro.RetirarPeca(posicaoTorre);
                torre.IncrementarQuantidadeMov();
                this.Tabuleiro.ColocarPeca(torre, posicaoTorreDestino);
            }
            return pecaCap;
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
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = this.Tabuleiro.RetirarPeca(destino);
            p.DecrementarQuantidadeMov();
            if(pecaCapturada != null)
            {
                this.Tabuleiro.ColocarPeca(pecaCapturada, destino);
                this.Capturadas.Remove(pecaCapturada);
            }
            this.Tabuleiro.ColocarPeca(p, origem);
            // Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao posicaoTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao posicaoTorreDestino = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torre = this.Tabuleiro.RetirarPeca(posicaoTorreDestino);
                torre.DecrementarQuantidadeMov();
                this.Tabuleiro.ColocarPeca(torre, posicaoTorre);
            }
            // Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao posicaoTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao posicaoTorreDestino = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torre = this.Tabuleiro.RetirarPeca(posicaoTorreDestino);
                torre.DecrementarQuantidadeMov();
                this.Tabuleiro.ColocarPeca(torre, posicaoTorre);
            }
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca peca = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, peca);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (EstaEmXeque(Adversario(JogadorAtual)))
            {
                this.Xeque = true;
            } else
            {
                this.Xeque = false;
            }
            if (TesteXequeMate(Adversario(JogadorAtual)))
            {
                this.Terminada = true;
            }
            Turno++;
            MudaJogador();
        }
        public bool TesteXequeMate(Cor cor)
        {
            if (this.Xeque)
            {
                foreach(Peca peca in PecasEmJogo(cor))
                {
                    bool[,] mat = peca.MovimentosPossiveis();
                    for(int i = 0; i < this.Tabuleiro.Linhas; i++)
                    {
                        for(int j = 0; j < this.Tabuleiro.Colunas; j++)
                        {
                            if (mat[i, j])
                            {
                                Posicao origem = peca.Posicao;
                                Posicao destino = new Posicao(i, j);
                                Peca pecaCap = ExecutaMovimento(origem, destino);
                                bool estaXeque = EstaEmXeque(cor);
                                DesfazMovimento(origem, destino, pecaCap);
                                if (!estaXeque)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            } else
            {
                return false;
            }
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
            if (!Tabuleiro.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino invalida!");
            }
        }
        public Cor Adversario(Cor cor)
        {
            if (cor == Cor.Branco)
            {
                return Cor.Preto;
            } else
            {
                return Cor.Branco;
            }
        }
        public bool EstaEmXeque(Cor cor)
        {
            Peca r = Rei(cor);
            if (r == null)
            {
                throw new TabuleiroException("O tabuleiro não possui um rei de cor " + cor + "!");
            }
            foreach(Peca peca in PecasEmJogo(Adversario(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[r.Posicao.Linha, r.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
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
        {/*
            ColocarNovaPeca('a', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('b', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 2, new Piao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 2, new Piao(Tabuleiro, Cor.Branco));*/
            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branco, this));/*
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 1, new Rainha(Tabuleiro, Cor.Branco));*/

            ColocarNovaPeca('a', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 7, new Piao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Rainha(Tabuleiro, Cor.Preto));
        }
    }
}
