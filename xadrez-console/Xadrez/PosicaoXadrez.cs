using System;
using Tabuleiro;

namespace Xadrez
{
    public class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }
        public PosicaoXadrez(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }
        public Posicao ToPosicao()
        {
            return new Posicao(8 - this.Linha, this.Coluna - 'a');
        }
        public override string ToString()
        {
            return $"{this.Coluna}{this.Linha}";
        }
    }
}
