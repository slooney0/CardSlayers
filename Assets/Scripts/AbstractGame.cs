using UnityEngine;

public abstract class AbstractGame : MonoBehaviour
{

    private int drawnCards;
    private string gameName;
    private string[] hand;

    public AbstractGame(int drawnCards, string gameName)
    {
        this.drawnCards = drawnCards;
        this.gameName = gameName;
    }
    
    public string[] draw()
    {
        for (int i = hand.Length; i < drawnCards; i++)
        {
            hand[i] = CardDManager.drawCard();
        }
        return hand;
    }

    public string[] draw(int drawnCards)
    {
        for (int i = hand.Length; i < drawnCards; i++)
        {
            hand[i] = CardDManager.drawCard();
        }
        return hand;
    }

    public string discard(string card)
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
        return "";
    }

    public void discardAll()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            CardDManager.discardSpecifiedCard(hand[i]);
            hand[i] = "";
        }
    }

    public abstract int score();
}
