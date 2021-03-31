using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorId;
    private Rigidbody rb;
    public Vector3 launchDist = new Vector3(0, 0, 1000);

    void Start()
    {
        gameObject.tag = "Interactable";
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Action(PlayerManager player)
    {
        if (player.CanIOpenDoor(doorId))
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(launchDist);
        }
    }

    public void ActionWithoutCheck()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(launchDist);
    }
}
