using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputVec;
    public float movementSpeed = 10;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(inputVec.x * Time.deltaTime * movementSpeed, 0, inputVec.y * Time.deltaTime * movementSpeed);
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        inputVec = value.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext value)
    {
        float inputSpace = value.ReadValue<float>();
        //jump = inputSpace != 0 ? true : false;
    }
}
