using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorId;

    void Start()
    {
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player)
    {
        if (player.CanIOpenDoor(doorId)) gameObject.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
    }
}
