using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private string name;
    private int health;
    private int attack;

    public Card(string name, int health, int attack)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
    }

    public string GetName()
    {
        return name;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetAttack()
    {
        return attack;
    }
}
