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
            Debug.Log("interacting...");

            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 4))
            {
                Debug.Log("Hit something");
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
            GameObject instant;
            Debug.Log("Removed: " + inventory.GetLastItem().GetName());

            if (inventory.GetLastItem() is AccessItem)
            {
                instant = Instantiate(accessPref, transform.position + transform.forward, Quaternion.identity);
                //instant.GetComponent<Bonus>().CreateItem();
            }

            if (inventory.GetLastItem() is BonusItem) 
            {
                instant = Instantiate(bonusPref, transform.position + transform.forward, Quaternion.identity);
                //instant.GetComponent<Access>().CreateItem();
                //instant.GetComponent<Bonus>().RecreateItem (inventory.GetLastItem().GetName(), inventory.GetLastItem().GetWeight(), 10);
            }

            inventory.DropLastItem();
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

    public bool DropItem(Item i)
    {
        return false;
    }
}