using Unity.VisualScripting;
using UnityEngine;

public class TexasHoldem : AbstractGame
{

    TexasHoldem() : base(5, "Texas Hold'em") { }
    
    AbstractGame aGame = new TexasHoldem();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int score()
    {
        return 0;
    }
}
