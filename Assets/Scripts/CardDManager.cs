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

    private static int[] basicCards = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 
        11 ,12, 13, 14, 15, 16, 17, 18, 19, 20, 
        21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 
        31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 
        41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 
        51, 52 };
    
    private static bool[] drawnCards = new bool[52];

    private static Stack<int> discard = new Stack<int>(52);

    private static List<int> deck = new List<int>(52);
    private static int deckSize = 52;
    private static int randomCardIdx;
    public static int card;

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
        discard.Push(-1);
        drawnCardsInt = 0;
        card = 0;
        deckSize = 52;
    }

    
    void Update()
    {
        if (drawnCardsInt == 52)
        {
            shuffle();
        }

        currentCard.text = "Current Card: " + card;

        int[] deckArray = deck.ToArray();
        currentDeck.text = "Current Deck: ";
        for (int i = 0; i < deckSize; i++)
        {
            currentDeck.text += deckArray[i].ToString() + ", ";
        }
        if (discard.Peek() >= 0)
        {
            discardedCard.text = "Discarded Card: " + discard.Peek();
        }
        else
        {
            discardedCard.text = "Empty";
        }
    }

    public static int drawCard()
    {
        if (card != 0)
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
        if (CardDManager.card != 0)
        {
            discard.Push(deck[idx]);
            CardDManager.card = 0;
        }
    }

    public static void discardSpecifiedCard(int card)
    {
        deck.Remove(card);
        discard.Push(card);
    }

    public static void shuffle()
    {
        int shuffledCardCount = 0;
        while (discard.Peek() != -1)
        {
            deck.Add(discard.Pop());
            shuffledCardCount++;
        }
        deckSize += shuffledCardCount;
        drawnCardsInt = 0;
    }
}
