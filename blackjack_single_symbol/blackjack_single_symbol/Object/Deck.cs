using blackjack_single_symbol.Exception;
using blackjack_single_symbol.Util;
using static blackjack_single_symbol.Util.LoopUtil;

namespace blackjack_single_symbol.Object
{
    public class Deck
    {
        private readonly LinkedList<Card> cards;
        private static readonly Random random = new();

        public Deck(){
            cards = new LinkedList<Card>();
            foreach (string value in Card.CARD_VALUES){
                cards.AddFirst(new Card(value));
            }
        }
        public Card? Draw(){
            return cards.PollFirst();
        }

        public void ReturnToTop(Card card){
            if (card.Display.Equals("A")){
                card.Value = Card.ACE_VALUE_11;
            }
            cards.AddFirst(card);
        }

        public void Cut(){
            int cuttingPoint = (int)random.NextInt64(cards.Count);
            Cut(cuttingPoint);
        }

        private void Cut(int topHalf)
        {
            LinkedList<Card> bottomHalf = new();
            topHalf.Times(() => bottomHalf.AddFirst(cards.PollFirst() ?? throw new DeckEmptyException()));
            while (bottomHalf.Count > 0){
                cards.AddLast(bottomHalf.PollFirst() ?? throw new DeckEmptyException("The bottom half is already exhausted. Check for error in implementation."));
            }
        }

        public void Shuffle(){
            int randomTime = (int)random.NextInt64(100);
            randomTime.Times(() => Cut());
        }
        public LinkedList<Card> Cards(){
            return cards;
        }
    }
}