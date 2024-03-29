using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Item selectedItem;
    public GameObject buttonPref;
    public GameObject invPanel;
    public GameObject playerOwningUI;

    private Dictionary<Item, GameObject> buttonDict = new Dictionary<Item, GameObject>();
    private Dictionary<GameObject, Item> itemDict = new Dictionary<GameObject, Item>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddUI(Item i)
    {
        GameObject instant = Instantiate(buttonPref, invPanel.transform);
        instant.GetComponentInChildren<Text>().text = i.GetName();
        //instant.GetComponent<RectTransform>().localScale.Set(1, 1, 1);
        Debug.Log(i + " ///// " + instant);
        buttonDict.Add(i, instant);
        itemDict.Add(instant, i);
    }

    public void RemoveUI(Item i)
    {
        Destroy(buttonDict[i]);
        itemDict.Remove(buttonDict[i]);
        buttonDict.Remove(i);
    }

    public void SelectItem(GameObject button)
    {
        Debug.Log(buttonDict.ContainsValue(button));
        if(itemDict.ContainsKey(button) && buttonDict.ContainsValue(button))
        {
            PlayerManager player = playerOwningUI.GetComponent<PlayerManager>();
            player.itemName = itemDict[button].GetName();
        }
    }
}