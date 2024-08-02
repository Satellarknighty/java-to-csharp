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
            topHalf.Times(() => bottomHalf.AddFirst(cards.PollFirst()));
            while (bottomHalf.Count > 0){
                cards.AddLast(bottomHalf.PollFirst());
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