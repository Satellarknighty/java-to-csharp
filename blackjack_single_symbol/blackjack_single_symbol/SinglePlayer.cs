using blackjack_single_symbol.Object;
using blackjack_single_symbol.Util;

using static blackjack_single_symbol.Parser.AvailableCommand;

namespace blackjack_single_symbol
{
    public class SinglePlayer
    {
        public static void StartGame(){
            bool gameOver = false;
            Parser.Parser userInput = new();
            while (!gameOver){
                Deck deck = new();
                Hand playerHand = new();
                OpponentHand opponentHand = new();
                SetUpBoard(deck, playerHand, opponentHand);
                bool roundOver = false;
                while(!roundOver){
                    roundOver = PlayRound(userInput, deck, playerHand, opponentHand);

                }
                gameOver = AskGameOver(userInput);
            }
            Console.WriteLine("Okay bye!\nType anything to quit.");
            Console.ReadLine();
        }

        private static void SetUpBoard(Deck deck, Hand firstHand, Hand secondHand)
        {
            deck.Shuffle();
            2.Times(() => {
                firstHand.Draw(deck);
                secondHand.Draw(deck);
            });
            DisplayGameState(firstHand, secondHand, deck);
        }

        private static void DisplayGameState(Hand firstHand, Hand secondHand, Deck deck)
        {
            Console.WriteLine($"You: \t {firstHand}");
            Console.WriteLine($"Opp: \t {secondHand}");
            Console.WriteLine($"Cards left in deck: {deck.Cards().Count}");
        }
        private static bool PlayRound(Parser.Parser userInput, Deck deck, Hand playerHand, OpponentHand opponentHand)
        {
            switch (userInput.GetPlayCommand()){
                case HIT:
                    if (WhenPlayerHits(deck, playerHand, opponentHand)){
                        return true;
                    }
                    break;
                case STAY:
                    WhenPlayerStays(deck, playerHand, opponentHand);
                    return true;
                case SHUFFLE:
                    deck.Shuffle();
                    break;
                case CHEAT:
                    playerHand.ReturnLastDrawnCardToDeck(deck);
                    break;
                case PEEK:
                    Reveal(playerHand, opponentHand);
                    return false;
                case QUIT:
                    return true;
                case UNKNOWN:
                    Console.WriteLine("Just say Hit or Stay man it's not that hard. \n");
                    return false;
                case HELP:
                    userInput.DisplayHelpDuringPlay();
                    return false;
            }
            DisplayGameState(playerHand, opponentHand, deck);
            return false;
        }

        private static bool WhenPlayerHits(Deck deck, Hand playerHand, OpponentHand opponentHand)
        {
            playerHand.Draw(deck);
            if (playerHand.IsBusted){
                DisplayResult(playerHand, opponentHand, true);
                return true;
            }
            if (!opponentHand.HasStayed){
                opponentHand.Action(playerHand, deck);
                if (opponentHand.IsBusted){
                    DisplayResult(playerHand, opponentHand, true);
                    return true;
                }
            }
            return false;
        }
        private static void WhenPlayerStays(Deck deck, Hand playerHand, OpponentHand opponentHand)
        {
            while(opponentHand.HasStayed is false){
                opponentHand.Action(playerHand, deck);
                if (opponentHand.IsBusted){
                    DisplayResult(playerHand, opponentHand, true);
                    return;
                }
            }
            DisplayResult(playerHand, opponentHand, false);
        }

        private static void DisplayResult(Hand firstHand, OpponentHand secondHand, bool busted)
        {
            if (busted is false){
                if (firstHand.TotalValue == secondHand.TotalValue){
                    Console.WriteLine("It's a draw.");
                }
                else {
                    Console.WriteLine(firstHand.TotalValue < secondHand.TotalValue ?
                                      "You lose!" : "You win!");
                }
            }
            else {
                Console.WriteLine(firstHand.IsBusted ? "You busted! You lose!" :
                "Opponent busted! You win!");
            }
            Reveal(firstHand, secondHand);
        }

        private static void Reveal(Hand firstHand, OpponentHand secondHand)
        {
            Console.WriteLine($"You: \t {firstHand}");
            Console.WriteLine($"Opp: \t {secondHand.Reveal()}");
        }
        private static bool AskGameOver(Parser.Parser userInput)
        {
            userInput.DisplayHelpDuringQuit();
            return userInput.GetQuitCommand().Equals(QUIT);
        }
    }
}