using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvButtonPress : MonoBehaviour
{
    public GameObject mainCanvas;
    public InventoryUI invUI;

    // Start is called before the first frame update
    void Start()
    {
        mainCanvas = transform.parent.gameObject.transform.parent.gameObject;
        invUI = mainCanvas.transform.GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pressed()
    {
        invUI.SelectItem(this.gameObject);
    }
}
