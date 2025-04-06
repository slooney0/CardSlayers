using UnityEngine;

public abstract class AbstractGame : MonoBehaviour
{

    private int drawnCards;
    private string gameName;
    private int[] hand;

    public AbstractGame(int drawnCards, string gameName)
    {
        this.drawnCards = drawnCards;
        this.gameName = gameName;
    }
    
    public int[] draw()
    {
        for (int i = hand.Length; i < drawnCards; i++)
        {
            hand[i] = CardDManager.drawCard();
        }
        return hand;
    }

    public int[] draw(int drawnCards)
    {
        for (int i = hand.Length; i < drawnCards; i++)
        {
            hand[i] = CardDManager.drawCard();
        }
        return hand;
    }

    public int discard(int card)
    {
        for (int i = 0; i < drawnCards; i++)
        {
            if (card == hand[i])
            {
                CardDManager.discardSpecifiedCard(card);
                for (int j = i; j < drawnCards - 1; j++)
                {
                    hand[j] = hand[j + 1];
                }
                return card;
            }
        }
        return -1;
    }

    public void discardAll()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            CardDManager.discardSpecifiedCard(hand[i]);
            hand[i] = -1;
        }
    }

    public abstract int score();
}
