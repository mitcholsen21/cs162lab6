using System;
using System.Collections.Generic;

public class Hand
{
    private List<Card> cards;

    // Constructor for an empty hand
    public Hand()
    {
        cards = new List<Card>();
    }

    // Constructor to create a hand with a specified number of cards dealt from a deck
    public Hand(Deck deck, int numberOfCards)
    {
        cards = new List<Card>();
        for (int i = 0; i < numberOfCards; i++)
        {
            cards.Add(deck.Deal());
        }
    }

    // Get the number of cards in the hand
    public int Count
    {
        get { return cards.Count; }
    }

    // Add a card to the hand
    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    // Discard a specific card from the hand and return it
    public Card Discard(Card card)
    {
        if (cards.Remove(card))
        {
            return card;
        }
        else
        {
            throw new ArgumentException("The card is not in the hand.");
        }
    }

    // Get a card based on its index
    public Card GetCard(int index)
    {
        if (index >= 0 && index < cards.Count)
        {
            return cards[index];
        }
        else
        {
            throw new ArgumentOutOfRangeException("index", "Index is out of range.");
        }
    }

    // Determine if the hand contains a specific card object
    public bool Contains(Card card)
    {
        return cards.Contains(card);
    }

    // Determine if the hand contains a card with a specific value and suit
    public bool Contains(CardValue value, CardSuit suit)
    {
        return cards.Exists(card => card.Value == value && card.Suit == suit);
    }

    // Determine if the hand contains a card with a specific value
    public bool Contains(CardValue value)
    {
        return cards.Exists(card => card.Value == value);
    }

    // Determine the index of a specific card object in the hand
    public int IndexOf(Card card)
    {
        return cards.IndexOf(card);
    }

    // Determine the index of a card with a specific value and suit in the hand
    public int IndexOf(CardValue value, CardSuit suit)
    {
        return cards.FindIndex(card => card.Value == value && card.Suit == suit);
    }

    // Determine the index of a card with a specific value in the hand
    public int IndexOf(CardValue value)
    {
        return cards.FindIndex(card => card.Value == value);
    }

    // Convert the hand to a string for displaying on the screen
    public override string ToString()
    {
        return string.Join(", ", cards);
    }
}

