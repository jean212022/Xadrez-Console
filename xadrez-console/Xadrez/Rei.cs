using System;
using Tabuleiro;

namespace Xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "R";
        }
    }
}
