using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Item selectedItem;
    public GameObject buttonPref;
    public GameObject invPanel;

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddUI(Item i)
    {
        CreateButton(i);
    }

    public void RemoveUI(Item i)
    {
        RemoveButton(i);
    }

    private void CreateButton(Item i)
    {
        GameObject instant = Instantiate(buttonPref, new Vector3(0, 0, 0), Quaternion.identity);
        instant.transform.SetParent(invPanel.transform);
        instant.GetComponentInChildren<Text>().text = i.GetName();
    }

    private void RemoveButton(Item i)
    {

    }
}