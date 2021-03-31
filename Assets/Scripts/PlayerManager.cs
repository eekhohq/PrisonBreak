using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;
    public string itemName;
    public float initialMaxWeight;
    public GameObject InventoryUI;
    public Transform playerCam;
    public GameObject mainCanvas;
    private InventoryUI invUI;
    public GameObject inpUI;

    private bool canClimb;
    private Rigidbody rb;
    private float upSpeed;
    private bool canAPI;

    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
        playerCam = this.gameObject.transform.GetChild(0);
        invUI = mainCanvas.transform.GetComponent<InventoryUI>();
        invUI.GetComponent<Canvas>().enabled = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void Update()
    {

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * 4, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.SphereCast(playerCam.transform.position, 0.5f, playerCam.transform.forward, out hit, 4))
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
            if (itemName == null)
            {
                DropItem(inventory.GetLastItem().GetName());
            }
            else
            {
                DropItem(itemName);
                itemName = null;
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canAPI)
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    inpUI.SetActive(true);
                    invUI.GetComponent<Canvas>().enabled = false;
                    EnableUI();
                }
                else if(Cursor.lockState == CursorLockMode.None)
                {
                    inpUI.SetActive(false);
                    DisableUI();
                }
            }
            else
            {
                inpUI.SetActive(false);
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    invUI.GetComponent<Canvas>().enabled = true;
                    EnableUI();
                }
                else if (Cursor.lockState == CursorLockMode.None)
                {
                    invUI.GetComponent<Canvas>().enabled = false;
                    DisableUI();
                }
            }
        }

        if (Input.GetKey(KeyCode.W) && canClimb)
        {
            rb.AddForce(0, upSpeed, 0);
        }
    }

    private void EnableUI()
    {
        Cursor.lockState = CursorLockMode.None;
        playerCam.gameObject.GetComponent<CameraMovement>().enabled = false;
    }

    private void DisableUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCam.gameObject.GetComponent<CameraMovement>().enabled = true;
    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);
        if (i != null)
        {
            inventory.RemoveItem(inventory.GetItemWithName(name));
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
            invUI.RemoveUI(i);
        }
    }

    public void RemoveItem(string name)
    {
        Item i = inventory.GetItemWithName(name);
        if (i != null)
        {
            inventory.RemoveItem(inventory.GetItemWithName(name));
            GameManager.Instance.DeleteItem(name);
            invUI.RemoveUI(i);
        }
    }

    public List<string> PassThroughRaft()
    {
        return inventory.GetRaftNames();
    }

    public bool AddItem(Item i)
    {
        Debug.Log("Added item " + i.GetName());
        if (inventory.AddItem(i))
        {
            invUI.AddUI(i);
            return true;
        }
        return false;
    }

    public bool CanIOpenDoor(int doorId)
    {
        return inventory.CanOpenDoor(doorId);
    }

    public bool CanICraftRaft(int needed)
    {
        return inventory.CanCraftRaft(needed);

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Triggered");
        if (collision.gameObject.CompareTag("Climb"))
        {
            canClimb = true;
            upSpeed = collision.gameObject.GetComponent<ClimbUp>().climbspeed;
        }
        else if (collision.gameObject.CompareTag("API"))
        {
            canAPI = true;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            collision.gameObject.GetComponent<OutsideTrigger>().OutsideTriggerHappenings(gameObject.GetComponent<PlayerMovement>());
            rb.Sleep();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Triggered but not");
        if (collision.gameObject.CompareTag("Climb"))
        {
            canClimb = false;
        }
        else if (collision.gameObject.CompareTag("API"))
        {
            canAPI = false;
        }
    }
}