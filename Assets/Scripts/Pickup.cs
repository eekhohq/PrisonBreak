using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public string itemName;
    public float weight;
    public Sprite itemSprite;

    private void Start()
    {
        gameObject.tag = "Interactable";
        GameManager.Instance.RegisterPickupItem(this);
    }

    public void Action(PlayerManager player)
    {
        if (player.AddItem(CreateItem()))
        {
            Remove();
        }
    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Respawn(Vector3 pos)
    {
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
    }

    public abstract Item CreateItem();
}
