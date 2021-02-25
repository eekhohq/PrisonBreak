using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Deck> decks = new List<Deck>();
    public Deck picked;

    public bool CreateDeck(int num)
    {
        //Ask for i
        return true;
    }

    public void ShuffleAll()
    {
        for (int i = 0; i < decks.Count - 1; i++)
        {
            int k = Random.Range(0, decks.Count);
            Deck temp = decks[i];
            decks[i] = decks[k];
            decks[k] = temp;
        }
    }

    public bool GetDeck(Deck deck)
    {
        if (decks.Contains(deck))
        {
            return true;
        }
        return false;   
    }

    public bool Pick(Deck deck)
    {
        
        if(decks.Contains(deck))
        {
            picked = deck;
            return true;
        }
        return false;
    }

    public Deck Lay()
    {
        Deck temp = picked;
        decks.Remove(picked);
        return temp;
    }
}
