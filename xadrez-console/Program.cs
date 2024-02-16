using System;
using Tabuleiro;
using Xadrez;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                while (!partidaDeXadrez.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);
                        Console.WriteLine("\nTurno: " + partidaDeXadrez.Turno);
                        Console.WriteLine("Aguardando jogada: {0}", partidaDeXadrez.JogadorAtual);
                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaDeXadrez.ValidarPosicaoDeOrigem(origem);
                        Console.Clear();
                        bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.Peca(origem).MovimentosPossiveis();
                        Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro, posicoesPossiveis);
                        Console.WriteLine("\nTurno: " + partidaDeXadrez.Turno);
                        Console.WriteLine("Aguardando jogada: {0}", partidaDeXadrez.JogadorAtual);
                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);
                        partidaDeXadrez.RealizaJogada(origem, destino);
                    }catch(TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
            } catch(TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}