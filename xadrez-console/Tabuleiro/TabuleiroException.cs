using System;

namespace xadrez_console.Tabuleiro
{
    public class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string message) : base(message) { }
    }
}
