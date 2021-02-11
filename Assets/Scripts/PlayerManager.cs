using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public float initialMaxWeight;
    public GameObject accessPref;
    public GameObject bonusPref;
    public GameObject InventoryUI;

    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
        //InventoryUI.GetComponent<InventoryUI>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 4))
            {
                //Debug.Log("Hit something");
                IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                if (i != null)
                {
                    Debug.Log("Hit an interactable.");
                    i.Action(this);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem("EA1");
        }
    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);
        if (i != null)
        {
            inventory.RemoveItem(inventory.GetItemWithName(name));
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
        }
    }

    public bool AddItem(Item i)
    {
        Debug.Log("Added item " + i.GetName());
        return inventory.AddItem(i);
    }

    public bool CanIOpenDoor(int doorId)
    {
        return inventory.CanOpenDoor(doorId);
    }
}