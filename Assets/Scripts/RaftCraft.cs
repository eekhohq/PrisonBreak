using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftCraft : MonoBehaviour, IInteractable
{
    public void Action(PlayerManager player)
    {
        Debug.Log("Can craft: " + player.CanICraftRaft(8));
        if (player.CanICraftRaft(8))
        {
            foreach (string s in player.PassThroughRaft())
            {
                player.RemoveItem(s);
            }
            Application.Quit();
            //Give raft
        }
    }
}
