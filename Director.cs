using System;

namespace cse210_02
{
    public class Director
    {
        bool isPlaying = true;
        int score = 300;
        int winPoints = 100;
        int losePoints = 75;
        int currentCard = 0;
        int nextCard = 0;
        string guess = "";
        string playAgain = "";
        
        Deck deck = new Deck();

        public Director()
        {

        }

        public void StartGame()
        {
            currentCard = deck.Draw();
            while (isPlaying)
            {
                mainGame();
                gameCheck();
            }
        }

        public void mainGame()
        {
            Console.WriteLine($"The card is: {currentCard}");

            do
            {
                nextCard = deck.Draw();
            }
            while (nextCard == currentCard);

            do 
            {
                Console.Write("Higher or Lower? (h/l): ");
                guess = Console.ReadLine();
            }
            while (guess != "h" && guess != "l");

            Console.WriteLine($"Next card was: {nextCard} ");

            if (guess == "h" && nextCard > currentCard)
            {
                score += winPoints;
            }
            else if (guess == "l" && nextCard < currentCard)
            {
                score += winPoints;
            }
            else if (guess == "h" && nextCard < currentCard)
            {
                score -= losePoints;
            }
            else if (guess == "l" && nextCard > currentCard)
            {
                score -= losePoints;
            }

            if (score < 0)
            {
                score = 0;
            }

            Console.WriteLine($"Your score is: {score}");

        }

        public void gameCheck()
        {
            if (score == 0)
            {
                isPlaying = false;
                Console.WriteLine("Haha, you lost sucker XP");
                return;
            }

            do
            {
            Console.Write("Play again? (y/n): ");
            playAgain = Console.ReadLine();
            }
            while (playAgain != "y" && playAgain != "n");

            isPlaying = (playAgain == "y");
            currentCard = nextCard;
        }
    }
}