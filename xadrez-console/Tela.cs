﻿using System;
using Xadrez;
using Tabuleiro;

namespace xadrez_console
{
    public class Tela
    {
        public static void ImprimirPeca(Peca peca)
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
        }
        public static void ImprimirTabuleiro(Tabuleiros tabuleiro)
        {
            for(int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{tabuleiro.Linhas - i}  ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if(tabuleiro.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        ImprimirPeca(tabuleiro.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
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
