using blackjack_single_symbol.Util;
using static blackjack_single_symbol.Util.LoopUtil;

namespace blackjack_single_symbol.Object
{
    public class Deck
    {
        private readonly LinkedList<Card> cards;
        static readonly Random random = new();

        public Deck(){
            cards = new LinkedList<Card>();
            foreach (string value in Card.CARD_VALUES){
                cards.AddFirst(new Card(value));
            }
        }
        public Card Draw(){
            return cards.First();
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
            10.Times(() => bottomHalf.AddFirst(cards.First()));
        }
    }
}