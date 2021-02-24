using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Item selectedItem;
    public GameObject buttonPref;
    public GameObject invPanel;

    private Dictionary<Item, GameObject> buttonDict = new Dictionary<Item, GameObject>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddUI(Item i)
    {
        GameObject instant = Instantiate(buttonPref, new Vector3(0, 0, 0), Quaternion.identity);
        instant.transform.SetParent(invPanel.transform);
        instant.GetComponentInChildren<Text>().text = i.GetName();
        instant.GetComponent<RectTransform>().localScale.Set(1, 1, 1);
        Debug.Log(i + " ///// " + instant);
        buttonDict.Add(i, instant);
    }

    public void RemoveUI(Item i)
    {
        Destroy(buttonDict[i]);
        buttonDict.Remove(i);
    }

    public void SelectItem(GameObject button)
    {
        Debug.Log(buttonDict.ContainsValue(button));
    }
}