using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPickupItem(Pickup i)
    {
        if (worldItems.ContainsKey(i.itemName)) Debug.LogError("Tried adding an item with the same name as another item to the inventory >> " + i.itemName);
        worldItems.Add(i.itemName, i);
    }

    public void DropItem(string name, Vector3 pos)
    {
        worldItems[name].Respawn(pos);
    }
}
