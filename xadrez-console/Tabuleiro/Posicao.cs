﻿using System;

namespace Tabuleiro
{
    public class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Posicao(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }
        public void DefinirValores(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }
        public override string ToString()
        {
            return $"({this.Linha}, {this.Coluna})";
        }
    }
}
