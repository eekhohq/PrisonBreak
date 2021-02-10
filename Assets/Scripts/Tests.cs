using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        inventory = new Inventory(150);
        TestInv();
        TestPuzzle();
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

    private void TestInv()
    {
        //Creating the items
        Debug.Log("INV SHIT HERE YEEET");
        AccessItem i = new AccessItem("Key for dwum", 10, 1);
        AccessItem ai = new AccessItem("Key for aiaiai", 20, 3);
        BonusItem j = new BonusItem("Potatoe", 65, 100);
        BonusItem bj = new BonusItem("Pota2", 10, 100);

        //Adding
        if (inventory.AddItem(i))
        {
            Debug.Log("Added " + i.GetName() + " To the inventory");
        }

        if (inventory.AddItem(ai))
        {
            Debug.Log("Added " + ai.GetName() + " To the inventory");
        }

        if (inventory.AddItem(j))
        {
            Debug.Log("Added " + j.GetName() + " To the inventory");
        }

        if (inventory.AddItem(bj))
        {
            Debug.Log("Added " + bj.GetName() + " To the inventory");
        }

        //inventory.DebugInv();

        //Can open door
        if (inventory.CanOpenDoor(1)) Debug.Log("Can open door 1");
        else Debug.Log("Can't open door 1");

        if (inventory.CanOpenDoor(2)) Debug.Log("Can open door 2");
        else Debug.Log("Can't open door 2");

        //Has and Remove
        if (inventory.HasItem(i)) Debug.Log("Has item " + i.GetName());
        else Debug.Log("Doesn't have " + i.GetName());

        if (inventory.RemoveItem(i)) Debug.Log("Removed item");
        else Debug.Log("Couldn't remove item");

        if (inventory.HasItem(i)) Debug.Log("Has item " + i.GetName());
        else Debug.Log("Doesn't have " + i.GetName());
    }

    private void TestPuzzle()
    {
        string answer1 = "boega";
        string answer2 = "fut";

        PuzzleItem puz1 = new PuzzleItem("Jeffrey", 10, "OeGa", "bOeGa");
        PuzzleItem puz2 = new PuzzleItem("Henk", 12, "Me", "faT");

        Debug.Log("R: " + puz1.GetRiddle() + "\n    A: " + puz1.GetAnswer());
        if (puz1.IsSolved(answer1)) Debug.Log("Is solved puz1");
        else Debug.Log("Answer 1: <" + answer1 + "> Was incorrect");

        Debug.Log("R: " + puz2.GetRiddle() + "\n    A: " + puz2.GetAnswer());
        if (puz2.IsSolved(answer2)) Debug.Log("Is solved puz2");
        else Debug.Log("Answer 2: <" + answer2 + "> Was incorrect");
    }
}
