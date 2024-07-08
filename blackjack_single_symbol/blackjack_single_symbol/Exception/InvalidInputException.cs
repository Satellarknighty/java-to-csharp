namespace blackjack_single_symbol.Exception
{
    public class InvalidInputException : System.Exception
    {
        public InvalidInputException() : base("The input is null.") {}
        public InvalidInputException(string message) : base(message){}

        public InvalidInputException(string message, System.Exception inner) : base(message, inner){}
    }
}