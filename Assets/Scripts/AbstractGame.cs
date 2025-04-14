using UnityEngine;

public abstract class AbstractGame : MonoBehaviour
{

    private int drawnCards;
    private string gameName;
    private SortedList hand;

    public AbstractGame(int drawnCards, string gameName)
    {
        this.drawnCards = drawnCards;
        this.gameName = gameName;
        hand = new SortedList(drawnCards * 2);
    }
    
    public SortedList drawHand()
    {
        for (int i = hand.getSize(); i < drawnCards; i++)
        {
            hand.add(CardDManager.drawCard());
        }
        return hand;
    }

    public SortedList draw(int drawnCards)
    {
        for (int i = hand.getSize(); i < drawnCards; i++)
        {
            hand.add(CardDManager.drawCard());
        }
        return hand;
    }

    public Card discard(Card card)
    {
        return hand.remove(card);
    }

    public void discardAll()
    {
        hand.discardHand();
    }

    public abstract int score();
}
