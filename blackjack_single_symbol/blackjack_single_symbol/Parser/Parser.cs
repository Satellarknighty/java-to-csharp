namespace blackjack_single_symbol.Parser
{
    public class Parser
    {
        private readonly Command command;
        public Parser(){
            command = new Command();
        }

        public AvailableCommand GetPlayCommand(){
            Console.WriteLine("Hit or Stay?");
            string? userInput = Console.ReadLine();
            if (userInput is null){
            }
            return command.GetPlayCommand(userInput);
        }
    }
}