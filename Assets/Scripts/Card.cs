using System;
using UnityEngine;

public class Card
{
    
    public enum Suit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds,
        Null,
        Empty
    }

    private Suit cardSuit;

    private int identifier;

    public Card(Suit cardSuit, int identifier)
    {
        this.cardSuit = cardSuit;
        this.identifier = identifier;
    }

    public Suit getSuit()
    {
        return cardSuit;
    }

    public int getIdentifier()
    {
        return identifier;
    }

    public string toString()
    {
        return cardSuit.ToString() + " " + identifier;
    }

    public Boolean equals(Card card)
    {
        if (card == null) return false;
        if (this.identifier == card.identifier && this.cardSuit.Equals(card.cardSuit)) return true;
        else return false;
    }
}
