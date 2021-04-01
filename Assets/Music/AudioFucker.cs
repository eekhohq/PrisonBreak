using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFucker : MonoBehaviour
{
    private AudioSource aus;

    [Header("Panning")]
    public bool PanSwitching;
    public float PanSwitchSpeed;
    public float used = 0;
    bool up;

    void Start()
    {
        aus = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PanSwitching)
        {
            if (used >= 1)
            {
                up = false;
            }
            else if (used <= -1)
            {
                up = true;
            }
            if (up)
            {
                used += PanSwitchSpeed;
            }
            else
            {
                used -= PanSwitchSpeed;
            }

        }
        aus.panStereo = used;
    }
}
