using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Internal;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CardDManager : MonoBehaviour
{
    
    private static Card emptyCard = new Card(Card.Suit.Empty, 0);

    private static CardList discard = new CardList();
    private static CardList deck = new CardList();
    private static int randomCardIdx;
    public static Card cCard;

    private static int drawnCardsInt;

    public Text currentCard; //To Be Removed
    public Text discardedCard; //To Be Removed
    public Text currentDeck; //To Be Removed

    void Start()
    {
        deck.createDeck();
        drawnCardsInt = 0;
    }

    
    void Update()
    {
        if (deck.getSize() == 0)
        {
            shuffle();
        }

        if (cCard != null)
        currentCard.text = "Current Card: " + cCard.toString();

        currentDeck.text = "Current Deck: ";
        for (int i = 0; i < deck.getSize(); i++)
        {
            if (deck.get(i) != null)
            currentDeck.text += deck.get(i).toString() + ", ";
        }
        if (discard.getSize() != 0)
        {
            discardedCard.text = "Discarded Card: " + discard.get(discard.getSize() - 1).toString();
        }
        else
        {
            discardedCard.text = "Empty";
        }
    }

    public static Card drawCard()
    {

        if (cCard != null && !cCard.equals(emptyCard))
        {
            print("discarded");
            discard.add(cCard);
        }

        randomCardIdx = UnityEngine.Random.Range(0, deck.getSize());

        print(randomCardIdx);

        drawnCardsInt++;
        cCard = deck.get(randomCardIdx);
        deck.remove(randomCardIdx);
        return cCard;
    }

    public static void discardCard(int idx)
    {
        if (!deck.get(idx).equals(emptyCard))
        {
            discard.add(deck.remove(idx));
        }
    }

    public static void discardSpecifiedCard(Card card)
    {
        if (card != null && !card.equals(emptyCard))
        {
            discard.add(card);
        }

        cCard = emptyCard;
    }

    public static void shuffle()
    {
        while (discard.getSize() != 0)
        {
            print("shuffled");

            deck.add(discard.remove(discard.getSize() - 1));
        }
        drawnCardsInt = 0;
    }
}
