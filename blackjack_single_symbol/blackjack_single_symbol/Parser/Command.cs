namespace blackjack_single_symbol.Parser
{
    public class Command{
        private readonly Dictionary<string, AvailableCommand> validPlayCommands;
        private readonly Dictionary<string, AvailableCommand> validQuitCommands;
        public Command(){
            validPlayCommands = new Dictionary<string, AvailableCommand>();
            validQuitCommands = new Dictionary<string, AvailableCommand>();
            GenerateValidPlayCommands();
            GenerateValidQuitCommands();
        }

        private void GenerateValidPlayCommands(){
            validPlayCommands.Add("hit", AvailableCommand.HIT);
            validPlayCommands.Add("stay", AvailableCommand.STAY);
            validPlayCommands.Add("cheat", AvailableCommand.CHEAT);
            validPlayCommands.Add("shuffle", AvailableCommand.SHUFFLE);
            validPlayCommands.Add("peek", AvailableCommand.PEEK);
            validPlayCommands.Add("quit", AvailableCommand.QUIT);
            validPlayCommands.Add("help", AvailableCommand.HELP);
        }
        private void GenerateValidQuitCommands(){
            validQuitCommands.Add("yes", AvailableCommand.YES);
            validQuitCommands.Add("y", AvailableCommand.YES);
            validQuitCommands.Add("no", AvailableCommand.QUIT);
            validQuitCommands.Add("n", AvailableCommand.QUIT);
            validQuitCommands.Add("quit", AvailableCommand.QUIT);
            validQuitCommands.Add("help", AvailableCommand.HELP);
        }

        public AvailableCommand GetPlayCommand(string input){
            return validPlayCommands.GetValueOrDefault(input.ToLower(), AvailableCommand.UNKNOWN);
        }

        public AvailableCommand GetQuitCommand(string input){
            return validQuitCommands.GetValueOrDefault(input.ToLower(), AvailableCommand.UNKNOWN);
        }

        public bool IsQuitCommand(string input){
            return validQuitCommands.ContainsKey(input.ToLower());
        }

        public void DisplayHelpPlayCommands(){
            Console.Write("Available commands are:");
            foreach(string key in validPlayCommands.Keys){
                Console.Write($" {key}");
            }
            Console.WriteLine();
        }

        public void DisplayHelpQuitCommands(){
            Console.Write("Available commands are:");
            foreach(string key in validQuitCommands.Keys){
                Console.Write($" {key}");
            }
            Console.WriteLine();
        }
    }
}
    