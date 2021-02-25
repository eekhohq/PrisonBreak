using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    //public Dictionary<Card, Card> cardsDict = new Dictionary<GameManager, Card>;
    private string name;
    private List<Card> deckCards = new List<Card>();
    private Card picked;

    public Deck(string name)
    {
        this.name = name;
    }

    public string GetDeck()
    {
        string temp = "Cards in deck:";
        foreach (Card i in deckCards)
        {
            temp += " " + i.GetName();
        }
        return temp;
    }

    public void AddToDeck(Card card)
    {
        deckCards.Add(card);
        //Was for testing purposes vvv
        if(picked == null)
        {
            picked = card;
        }
    }

    //Shuffle the deck
    public void Shuffle()
    {
        for (int i = 0; i < deckCards.Count - 1; i++)
        {
            int k = Random.Range(0, deckCards.Count);
            Card temp = deckCards[i];
            deckCards[i] = deckCards[k];
            deckCards[k] = temp;
        }
    }

    //Pick the wanted card
    public bool Pick(Card card)
    {
        if (deckCards.Contains(card))
        {
            picked = card;
            return true;
        }
        return false;
    }

    public Card GetPicked()
    {
        return picked;
    }

    //Place/Use card on game map
    public Card Lay()
    {
        Card temp = picked;
        deckCards.Remove(picked);
        return temp;
    }
}
