using blackjack_single_symbol.Exception;

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
            string userInput = Console.ReadLine() ?? throw new InvalidInputException();
            return command.GetPlayCommand(userInput);
        }

        public AvailableCommand GetQuitCommand(){
            Console.WriteLine("Play again? (Y/N)");
            string userInput = Console.ReadLine() ?? throw new InvalidInputException();
            while (!command.IsQuitCommand(userInput)) {
                Console.WriteLine("Just type \"Y\" for yes or \"N\" for no man.");
                userInput = Console.ReadLine() ?? throw new InvalidInputException();
            }
            return command.GetQuitCommand(userInput);
        }

        public void DisplayHelpDuringPlay(){
            command.DisplayHelpPlayCommands();
        }

        public void DisplayHelpDuringQuit(){
            command.DisplayHelpQuitCommands();
        }
    }
}