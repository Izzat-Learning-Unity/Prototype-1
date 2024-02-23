using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float speed = 30.0f;
    private float turnSpeed = 60.0f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Get the Input from the player
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");

        //Code used to move the vehicle forwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //Code used to make the vehicle rotate (for turning)
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

    }
}
