using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : Pickup
{
    public override Item CreateItem()
    {
        return new RaftItem(itemName, weight);
    }
}
