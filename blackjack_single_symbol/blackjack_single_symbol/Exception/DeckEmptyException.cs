using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackjack_single_symbol.Exception
{
    public class DeckEmptyException : System.Exception
    {
        public DeckEmptyException() : base("The Deck doesn't have any cards left.") {}
        public DeckEmptyException(string message) : base(message) {}
        public DeckEmptyException(string message, System.Exception innerException) : base(message, innerException) {}
    }
}