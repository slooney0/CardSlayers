using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Button draw;
    [SerializeField] Button discard;
    [SerializeField] Button shuffle;

    void Start()
    {
        draw.onClick.AddListener(drawCard);
        discard.onClick.AddListener(discardCard);
        shuffle.onClick.AddListener(shuffleCard);
    }

    
    void Update()
    {
        
    }

    private void drawCard()
    {
        CardDManager.drawCard();
    }

    private void discardCard()
    {
        CardDManager.discardSpecifiedCard(CardDManager.cCard);
    }

    private void shuffleCard()
    {
        CardDManager.shuffle();
    }
}
