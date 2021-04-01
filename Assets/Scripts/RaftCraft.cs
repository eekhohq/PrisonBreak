using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftCraft : MonoBehaviour, IInteractable
{
    public GameObject boat;
    public GameObject track2;
    public void Action(PlayerManager player)
    {
        Debug.Log("Can craft: " + player.CanICraftRaft(8));
        if (player.CanICraftRaft(8))
        {
            foreach (string s in player.PassThroughRaft())
            {
                player.RemoveItem(s);
            }
            //50/50 to decide whether you get boat or just leave lol
            /*if (Random.Range(0, 2) == 1)
            {
                Application.Quit();
            }
            else
            {*/
            player.GetComponentInChildren<Camera>().enabled = false;
            boat.SetActive(true);
            track2.SetActive(false);
            //}
            //Give raft
        }
    }
}
