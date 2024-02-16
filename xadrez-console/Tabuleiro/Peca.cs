﻿using System;

namespace Tabuleiro
{
    public abstract class Peca
    {
        public Posicao? Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QuantMovimentos { get; protected set; }
        public Tabuleiros Tabuleiro { get; protected set; }
        public Peca(Tabuleiros tabuleiro, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            QuantMovimentos = 0;
            Tabuleiro = tabuleiro;
        }
        public void IncrementarQuantidadeMov()
        {
            this.QuantMovimentos++;
        }
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = this.MovimentosPossiveis();
            for (int i = 0; i < this.Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < this.Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PodeMoverPara(Posicao posicao)
        {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
