using System;

namespace cse210_02
{
    public class Deck
    {
        public int cardValue;
        public int Draw()
        {
            Random random = new Random();
            cardValue = random.Next(1, 14);
            return cardValue;
        }
    }
}
