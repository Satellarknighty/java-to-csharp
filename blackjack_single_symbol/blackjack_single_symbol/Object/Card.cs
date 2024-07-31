using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace blackjack_single_symbol.Object
{
    public class Card
    {
        public static readonly string[] CARD_VALUES = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];

        public static readonly int ACE_VALUE_11 = 11;

        public static readonly int ACE_VALUE_1 = 1;

        public static readonly int JQK_VALUE = 10;
        public int Value {get; set;}

        private string Display {get; }
        
        public Card(string display){
            Display = display;
            Value = GetValueFromDisplay(display);
        }

        private int GetValueFromDisplay(string display)
        {
            return display switch{
                "A" => ACE_VALUE_11,
                "J" => JQK_VALUE,
                "Q" => JQK_VALUE,
                "K" => JQK_VALUE,
                _ => Int32.Parse(display)
            };
        }

        public Card(string display, int value){
            Display = display;
            Value = value;
        }

        public override string ToString()
        {
            return $"[{Display}]";
        }

        public override bool Equals(object? obj)
        {
            return obj is Card card &&
                   Value == card.Value &&
                   Display == card.Display;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Display);
        }
    }
}