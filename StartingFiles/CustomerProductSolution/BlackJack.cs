using System;

public class Program
{
    public static void Main(string[] args)
    {
        int playerWins = 0;
        int dealerWins = 0;
        bool playAgain = true;

        while (playAgain)
        {
            // Create a deck, shuffle it and deal initial cards
            Deck deck = new Deck();
            deck.Shuffle();

            BlackjackHand playerHand = new BlackjackHand(deck, 2);
            BlackjackHand dealerHand = new BlackjackHand(deck, 2);

            Console.WriteLine("Your hand: " + playerHand);
            Console.WriteLine("Dealer's hand: " + dealerHand.GetCard(0) + ", [hidden]");

            // Player's turn
            bool playerBusted = false;
            while (true)
            {
                Console.WriteLine("Your current score: " + playerHand.GetScore());
                Console.WriteLine("Do you want to 'hit' or 'stand'?");
                string choice = Console.ReadLine().ToLower();

                if (choice == "hit")
                {
                    playerHand.AddCard(deck.Deal());
                    Console.WriteLine("Your hand: " + playerHand);

                    if (playerHand.IsBusted())
                    {
                        Console.WriteLine("You busted! Your score: " + playerHand.GetScore());
                        playerBusted = true;
                        dealerWins++;
                        break;
                    }
                }
                else if (choice == "stand")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose 'hit' or 'stand'.");
                }
            }

            // Dealer's turn
            if (!playerBusted)
            {
                Console.WriteLine("Dealer's hand: " + dealerHand);
                while (dealerHand.GetScore() <= 16)
                {
                    dealerHand.AddCard(deck.Deal());
                    Console.WriteLine("Dealer hits: " + dealerHand);
                }

                Console.WriteLine("Dealer's final hand: " + dealerHand);
                Console.WriteLine("Dealer's final score: " + dealerHand.GetScore());

                if (dealerHand.IsBusted() || playerHand.GetScore() > dealerHand.GetScore())
                {
                    Console.WriteLine("You win!");
                    playerWins++;
                }
                else if (playerHand.GetScore() < dealerHand.GetScore())
                {
                    Console.WriteLine("Dealer wins!");
                    dealerWins++;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }
            }

            // Display the current score
            Console.WriteLine($"Score: Player {playerWins} - Dealer {dealerWins}");

            // Ask if the player wants to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = playAgainInput == "yes";
        }
    }
}

