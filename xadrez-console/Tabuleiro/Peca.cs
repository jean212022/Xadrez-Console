using System;

namespace Tabuleiro
{
    public class Peca
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
    }
}
