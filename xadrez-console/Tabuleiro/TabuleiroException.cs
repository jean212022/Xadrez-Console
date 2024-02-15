using System;

namespace Tabuleiro
{
    public class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string message) : base(message) { }
    }
}
