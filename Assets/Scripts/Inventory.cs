using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private float weight = 0;
    public float maxWeight = 100;

    void Start()
    {

    }


    void Update()
    {

    }

    public bool AddItem(Item i)
    {
        if (weight + i.GetWeight() <= maxWeight)
        {
            weight += i.GetWeight();
            items.Add(i);
            return true;
        }
        else return false;
    }

    public bool RemoveItem(Item i)
    {
        bool succes = items.Remove(i);
        if (succes)
        {
            weight -= i.GetWeight();
        }
        return succes;
    }

    public bool HasItem(Item i)
    {
        return items.Contains(i);
    }

    public bool CanOpenDoor(int id)
    {
        bool result = false;

        foreach (Item item in items)
        {
            if (item is AccessItem)
            {
                if (((AccessItem)item).OpensDoor(id))
                {
                    result = true;
                }
            }
        }

        return result;
    }
    public int Count()
    {
        return items.Count;
    }

    public float GetWeight()
    {
        return weight;
    }

    public void DebugInv()
    {
        Debug.Log("Inventory has " + items.Count + " items");
        Debug.Log("Total weight: " + weight + "KG");
    }
}
