using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Card one = new Card("One", 1, 1);
        Card two = new Card("Two", 2, 2);
        Card three = new Card("Three", 3, 3);
        Card four = new Card("Four", 4, 4);

        Deck Gowo = new Deck("Giant OwO");
        Gowo.AddToDeck(one);
        Gowo.AddToDeck(two);
        Gowo.AddToDeck(three);
        //Gowo.AddToDeck(four);

        Debug.Log(Gowo.GetDeck());
        Gowo.Shuffle();
        Debug.Log(Gowo.GetDeck());

        Debug.Log(Gowo.Pick(one));
        Debug.Log("Currently picked card: " + Gowo.GetPicked().GetName());
        Debug.Log(Gowo.Pick(four));
        Debug.Log("Currently picked card: " + Gowo.GetPicked().GetName());
        Debug.Log(Gowo.Lay().GetName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
