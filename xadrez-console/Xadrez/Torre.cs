using System;
using Tabuleiro;

namespace Xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiros tabuleiro, Cor cor) : base(tabuleiro, cor) { }
        public override string ToString()
        {
            return "T";
        }
    }
}
