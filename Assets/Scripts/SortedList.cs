using UnityEngine;
using UnityEngine.Rendering;

public class SortedList
{

    private int size;
    private Card[] cards;

    public SortedList(int capacity)
    {
        cards = new Card[capacity];
        size = 0;
    }

    public void add(Card card)
    {
        for (int i = 0; i < size; i++)
        {
            if (cards[i].getSuit() == card.getSuit())
            {
                if (cards[i].getIdentifier() < card.getIdentifier() && cards[i + 1].getIdentifier() > card.getIdentifier())
                {
                    add(card, i);
                }
                else if (i == cards.Length - 1)
                {
                    add(card, i);
                }

            }
            else if (i == cards.Length - 1)
            {
                add(card, i);
            }
        }
    }

    private void add(Card card, int index)
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

    private Card remove(Card card, int index)
    {
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

    public void discardHand()
    {
        for (int i = 0; i <  cards.Length; i++)
        {
            cards[i] = null;
        }
    }

    public int getSize()
    {
        return size;
    }
}
