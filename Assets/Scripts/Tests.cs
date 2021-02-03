using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    private void Start()
    {
        TestCreateItem();
    }

    private void TestCreateItem()
    {
        Item i = new AccessItem("Key for dwum", 10, 1);
        DebugItem(i);

        AccessItem ai = new AccessItem("Key for aiaiai", 10, 2);
        DebugItem(ai);

        Item j = new BonusItem("Potatoe", 2, 100);
        DebugItem(j);

        BonusItem bj = new BonusItem("Pota2", 2, 100);
        DebugItem(bj);

    }

    private void DebugItem(Item i)
    {
        string defaultInfo = "ITEM CREATED: " + i.GetName() + " // " + i.GetWeight() + "KG";
        string extraInfo = "";
        //Interspection
        if (i is AccessItem)
        {
            AccessItem ai = (AccessItem)i;
            extraInfo = "and opens door: " + ai.GetDoorId();
        }
        else if (i is BonusItem)
        {
            BonusItem ai = (BonusItem)i;
            extraInfo = "and opens door: " + ai.GetPoints();
        }

        Debug.Log(defaultInfo + extraInfo);
    }
}
