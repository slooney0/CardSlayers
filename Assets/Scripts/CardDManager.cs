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

    private static String[] basicCards = { "CA", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C0", "CJ", "CQ", "CK", 
                                           "DA", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D0", "DJ", "DQ", "DK",
                                           "SA", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S0", "SJ", "SQ", "SK",
                                           "HA", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H0", "HJ", "HQ", "HK"};
    
    private static Stack<String> discard = new Stack<String>(52);

    private static List<String> deck = new List<String>(52);
    private static int deckSize = 52;
    private static int randomCardIdx;
    public static String card;

    private static int drawnCardsInt;

    public Text currentCard; //To Be Removed
    public Text discardedCard; //To Be Removed
    public Text currentDeck; //To Be Removed

    void Start()
    {
        deck.Clear();
        for (int i = 0; i < basicCards.Length; i++)
        {
            deck.Add(basicCards[i]);
        }
        discard.Clear();
        discard.Push("-1");
        drawnCardsInt = 0;
        card = "";
        deckSize = 52;
    }

    
    void Update()
    {
        if (drawnCardsInt == 52)
        {
            shuffle();
        }

        currentCard.text = "Current Card: " + card;

        String[] deckArray = deck.ToArray();
        currentDeck.text = "Current Deck: ";
        for (int i = 0; i < deckSize; i++)
        {
            currentDeck.text += deckArray[i].ToString() + ", ";
        }
        if (discard.Peek() != "-1")
        {
            discardedCard.text = "Discarded Card: " + discard.Peek();
        }
        else
        {
            discardedCard.text = "Empty";
        }
    }

    public static String drawCard()
    {
        if (card != "")
        {
            discard.Push(card);
        }
        randomCardIdx = UnityEngine.Random.Range(0, deckSize);
        drawnCardsInt++;
        card = deck[randomCardIdx];
        deck.RemoveAt(randomCardIdx);
        deckSize--;
        return card;
    }

    public static void discardCard(int idx)
    {
        if (CardDManager.card != "")
        {
            discard.Push(deck[idx]);
            CardDManager.card = "";
        }
    }

    public static void discardSpecifiedCard(String card)
    {
        deck.Remove(card);
        discard.Push(card);
        CardDManager.card = "";
    }

    public static void shuffle()
    {
        int shuffledCardCount = 0;
        while (discard.Peek() != "-1")
        {
            deck.Add(discard.Pop());
            shuffledCardCount++;
        }
        deckSize += shuffledCardCount;
        drawnCardsInt = 0;
    }
}
