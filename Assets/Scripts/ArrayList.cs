using UnityEngine;

public class CardList
{

    private Card[] cards;
    private int size;

    public CardList()
    {
        cards = new Card[52 * 2];
        size = 0;
    }

    public void createDeck()
    {
        for (int i = 1; i <= 13; i++)
        {
            add(new Card(Card.Suit.Hearts, i));
            add(new Card(Card.Suit.Diamonds, i));
            add(new Card(Card.Suit.Spades, i));
            add(new Card(Card.Suit.Clubs, i));
        }
    }

    public void add(Card card)
    {
        if (card != null)
        {
            add(card, size);
        }
    }

    public void add(Card card, int index)
    {
        if (card != null)
        {
            Card next = cards[index];
            for (int i = index + 1; i < size + 1; i++)
            {
                Card temp = cards[i];
                cards[i] = next;
                next = temp;
            }
            cards[index] = card;
            size++;
        }
    }

    public Card remove(Card card)
    {
        for (int i = 0; i < size; i++)
        {
            if (cards[i] == card)
            {
                return remove(card, i);
            }
        }
        return null;
    }

    public Card remove(int index)
    {
        return (remove(get(index), index));
    }

    private Card remove(Card card, int index)
    {
        if (size == 0)
        {
            return null;
        }

        Card removedCard = cards[index];

        for (int i = index; i < size - 1; i++)
        {
            cards[i] = cards[i + 1];
        }

        cards[size - 1] = null;
        size--;

        return removedCard;
    }

    public Card get(int index)
    {
        return cards[index];
    }

    public int getSize()
    {
        return size;
    }

}
