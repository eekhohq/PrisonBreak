using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTrigger : MonoBehaviour
{
    public GameObject blockcade;
    public GameObject track1;
    public GameObject track2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OutsideTriggerHappenings(PlayerMovement player)
    {
        player.movementSpeed = 10;
        blockcade.SetActive(true);
        Destroy(this.gameObject);
        track1.SetActive(false);
        track2.SetActive(true);
    }
}
