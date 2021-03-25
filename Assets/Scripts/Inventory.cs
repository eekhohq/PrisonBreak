using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> items;
    private float weight;
    public float maximumWeight;

    //Run's first
    public Inventory()
    {
        items = new List<Item>();
        weight = 0;
        maximumWeight = 100;
    }

    //Run's after
    public Inventory(float maximumWeight) : this()
    {
        this.maximumWeight = maximumWeight;
    }

    public bool SetMaxWeight(float maxw)
    {
        if (weight > maxw)
        {
            maximumWeight = maxw;
            return true;
        }
        else return false;
    }

    public bool AddItem(Item i)
    {
        if (weight + i.GetWeight() <= maximumWeight)
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

    public bool CanCraftRaft (int itemCount)
    {
        int count = 0;
        int needed = itemCount;
        foreach (Item item in items)
        {
            if (item is RaftItem)
            {
                count++;
            }
        }
        if (count == itemCount)
        {
            return true;
        }
        else return false;
    }

    public List<string> GetRaftNames()
    {
        List <string> names = new List<string>();
        foreach (Item item in items)
        {
            if (item is RaftItem)
            {
                names.Add(item.GetName());
            }
        }
        return names;
    }

    public Item GetItemWithName(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == name) return items[i];
        }
        return null;
    }

    public int Count()
    {
        return items.Count;
    }

    public float GetWeight()
    {
        return weight;
    }

    public Item GetLastItem()
    {
        return items[items.Count - 1];
    }

    /*
    public bool DropItem(Item i)
    {
        bool succes = false;
        if (RemoveItem(i) && succes) return true;
        return false;
    }

    public bool DropItems()
    {
        foreach (Item item in items)
        {
            if (DropItem(item)) RemoveItem(item);
        }

        if (items.Count == 0)
        {
            return true;
        }
        return false;
    }

    public void DebugInv()
    {
        Debug.Log("Inventory has " + items.Count + " items");
        Debug.Log("Total weight: " + weight + "KG");
    }

    public void DebugItem(Item i)
    {
        switch (i)
        {
            case AccessItem:
                break;
            default:
                break;
        }
        if(i == AccessItem) { 
        }
    }*/
}
