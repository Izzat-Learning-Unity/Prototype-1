using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControllerT : MonoBehaviour
{
    //Private Variables
    [SerializeField] private float horsePower = 0;
    [SerializeField] private int speed;
    [SerializeField] private int rpm;

    private float turnSpeed = 60.0f;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody playerRB;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the Input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Code used to move the vehicle forwards
            playerRB.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //Code used to make the vehicle rotate (for turning)
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = (int)(playerRB.velocity.magnitude * 2.237f);

            speedometerText.SetText("Speed: " + speed + " mph");

            rpm = (speed % 30) * 40;

            rpmText.SetText("RPM: " + rpm);
        }
        
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
            return true;
        else
            return false;
    }
}
