using System;
using Tabuleiro;
using Xadrez;
using xadrez_console.Tabuleiro;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Posicao p = new Posicao(3, 4);
                Tabuleiros tabuleiro = new Tabuleiros(8, 8);
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new Posicao(1, 4));
                tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preto), new Posicao(2, 4));
                Tela.ImprimirTabuleiro(tabuleiro);
            } catch(TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}