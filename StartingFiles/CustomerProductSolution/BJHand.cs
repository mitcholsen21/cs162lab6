using System;
using System.Collections.Generic;

public class BJHand : Hand
{
    // Constructor for an empty blackjack hand
    public BJHand() : base() { }

    // Constructor to create a blackjack hand with a specified number of cards dealt from a deck
    public BJHand(Deck deck, int numberOfCards) : base(deck, numberOfCards) { }

    // Determine if the hand has an Ace
    public bool HasAce()
    {
        return Contains(CardValue.Ace);
    }

    // Get the score of the hand
    public int GetScore()
    {
        int score = 0;
        int numberOfAces = 0;

        foreach (var card in cards)
        {
            if (card.Value == CardValue.Ace)
            {
                numberOfAces++;
                score += 11; // Initially count aces as 11
            }
            else if (card.Value >= CardValue.Ten && card.Value <= CardValue.King)
            {
                score += 10; // Face cards are worth 10
            }
            else
            {
                score += (int)card.Value; // Numeric cards are worth their value
            }
        }

        // Adjust for aces if the score is greater than 21
        while (score > 21 && numberOfAces > 0)
        {
            score -= 10; // Convert an ace from 11 to 1
            numberOfAces--;
        }

        return score;
    }

    // Determine if the hand is busted (score is greater than 21)
    public bool IsBusted()
    {
        return GetScore() > 21;
    }
}

