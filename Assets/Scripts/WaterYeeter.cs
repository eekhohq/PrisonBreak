using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterYeeter : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 direction;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 pos = rb.position;
            rb.position += direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(pos);
        }
    }

    void SetDirection(GameObject player)
    {
        direction = player.GetComponent<Rigidbody>().velocity;
        direction.y = 0f;
        //direction = direction.normalized;
        Debug.Log("In vel: " + direction);
        direction = -direction;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            SetDirection(player);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        /*Debug.Log("Out vel: " + direction);
        player.GetComponent<Rigidbody>().Sleep();
        Debug.Log("Last vel: " + direction);*/
    }
}
