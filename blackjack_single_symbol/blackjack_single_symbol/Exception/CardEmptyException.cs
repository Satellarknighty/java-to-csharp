namespace blackjack_single_symbol.Exception
{
    public class CardEmptyException : System.Exception
    {
        public CardEmptyException() : base("No more card in Hand. Check for error in implementation."){}
        public CardEmptyException(string message) : base(message) {}
        public CardEmptyException(string message, System.Exception innerException) : base(message, innerException) {}

    }
}