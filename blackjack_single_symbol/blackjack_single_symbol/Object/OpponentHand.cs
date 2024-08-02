using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using blackjack_single_symbol.Exception;
using blackjack_single_symbol.Util;

namespace blackjack_single_symbol.Object
{
    public class OpponentHand : Hand
    {
        public bool HasStayed { get; private set; }
        private static readonly Random random = new();
        public OpponentHand() : base(){
            HasStayed = false;
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            Card firstCard = Cards.PollFirst() ?? throw new CardEmptyException();
            builder.Append(firstCard);
            Cards.Count.Times(() => builder.Append("[X]"));
            builder.Append($"\t Value: {firstCard.Value} + ?");
            return builder.ToString();
        }
        public string Reveal(){
            return base.ToString();
        }

        /**
        Remember to implement console write line on the caller.
        */
        public void Action(Hand opposingHand, Deck deck){
            if(!HasStayed){
                float probability = CalculateProbability(opposingHand, deck);
                if (random.NextInt64(1,11) <= probability){
                    Draw(deck);
                }
                else{
                    HasStayed = true;
                }
            }
        }

        private float CalculateProbability(Hand opposingHand, Deck deck){
            int valueOfBestCard = LIMIT_BEFORE_BUST - TotalValue;
            if (valueOfBestCard >= Card.JQK_VALUE){
                return valueOfBestCard;
            }
            int numberOfGoodCards = valueOfBestCard;
            foreach (Card card in Cards){
                if ((card.Value == Card.ACE_VALUE_11 ? Card.ACE_VALUE_1 : card.Value) <= valueOfBestCard){
                    numberOfGoodCards--;
                }
            }
            var last = opposingHand.Cards.Last ?? throw new CardEmptyException();
            if (last.Value.Value <= valueOfBestCard){
                numberOfGoodCards--;
            }
            return numberOfGoodCards / deck.Cards().Count;
        }
    }
}