
using System.Text;
using blackjack_single_symbol.Exception;
using blackjack_single_symbol.Util;

namespace blackjack_single_symbol.Object
{
    public class Hand
    {
        public int TotalValue{ get; private set; }
        public LinkedList<Card> Cards {get;}
        public bool IsBusted{ get; private set; }
        private protected static readonly int LIMIT_BEFORE_BUST = 21;

        public Hand(){
            TotalValue = 0;
            Cards = new();
            IsBusted = false;
        }

        public void Draw(Deck deck){
            Card drawnCard = deck.Draw() ?? throw new DeckEmptyException();
            Cards.AddFirst(drawnCard);
            CalculateTotalValue();
        }

        public void CalculateTotalValue()
        {
            TotalValue = 0;
            Card? ace = null;
            foreach(Card card in Cards){
                if(card.Display is "A"){
                    ace = card;
                    continue;
                }
                TotalValue += card.Value;
            }
            if(ace is not null){
                if (TotalValue + Card.ACE_VALUE_11 > LIMIT_BEFORE_BUST){
                    ace.Value = Card.ACE_VALUE_1;
                }
                else{
                    ace.Value = Card.ACE_VALUE_11;
                }
                TotalValue += ace.Value;
            }
            IsBusted = TotalValue > LIMIT_BEFORE_BUST;
        }

        public void ReturnLastDrawnCardToDeck(Deck deck){
            Card? removedCard = Cards.PollFirst();
            if (removedCard is null){
                return;
            }
            deck.ReturnToTop(removedCard);
            CalculateTotalValue();
        }
        public override string ToString()
        {
            StringBuilder builder = new();
            
            foreach(Card card in Cards.DescendingIterator()){
                builder.Append(card);
            }
            builder.Append($"\t Value: {TotalValue}");
            return builder.ToString();
        }
    }
}