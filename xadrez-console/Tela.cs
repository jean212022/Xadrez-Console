using System.Collections.Generic;
using Xadrez;
using Tabuleiro;

namespace xadrez_console
{
    public class Tela
    {
        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            } else
            {
                if (peca.Cor == Cor.Branco)
                {
                    Console.Write(peca);
                } else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        public static void ImprimirTabuleiro(Tabuleiros tabuleiro)
        {
            for(int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{tabuleiro.Linhas - i}  ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
        }
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("\nTurno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            if (partida.Xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("\nPecas capturadas: ");
            Console.Write("Bracas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branco));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preto));
            Console.ForegroundColor = aux;
        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.WriteLine("]");
        }
        public static void ImprimirTabuleiro(Tabuleiros tabuleiro, bool[,] possiveisMovimentos)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor, fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{tabuleiro.Linhas - i}  ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (possiveisMovimentos[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    } else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("   a b c d e f g h");
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string? resp = Console.ReadLine();
            char coluna = resp[0];
            int linha = int.Parse(resp[1]+"");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
