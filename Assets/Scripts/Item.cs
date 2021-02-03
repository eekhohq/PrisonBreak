using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //private float val = Mathf.Cos(1) * 50 + 50;

    //Properties
    private string name;
    private float weight;

    //Constructor
    public Item(string name, float weight)
    {
        this.name = name;
        this.weight = weight;
        Debug.Log("ITEM CREATED: " + name + " // " + weight + "KG");
    }

    /*//Polymorphishm!!!! Means multiple functions by the same name.
    public Item(float weight)
    {
        this.name = "Unnamed";
        this.weight = weight;
    }*/

    //Methods
    public string GetName()
    {
        return name;
    }

    public float GetWeight()
    {
        return weight;
    }
}
