
namespace blackjack_single_symbol.Util
{
    public static class LinkedListUtil
    {
        public  static E? PollFirst<E>(this LinkedList<E> list){
            if (list.First is null){
                return default;
            }
            E element = list.First.Value;
            list.RemoveFirst();
            return element;
        }

        public static E? PollLast<E>(this LinkedList<E> list){
            if (list.Last is null){
                return default;
            }
            E element = list.Last.Value;
            list.RemoveLast();
            return element;
        }
    }
}