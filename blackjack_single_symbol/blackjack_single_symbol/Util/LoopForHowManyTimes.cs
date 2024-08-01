namespace blackjack_single_symbol.Util
{
    public static class LoopUtil
    {
        public static void Times(this int time, Action action){
            for (int i = 0; i < time; i++){
                action();
            }
        }

        public static void Times(this int time, Action<int> action){
            for (int i = 0; i < time; i++){
                action(i);
            }
        }
    }
}