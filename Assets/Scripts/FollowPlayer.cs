using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    private bool isThirdPerson = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isThirdPerson)
            {
                isThirdPerson = false;
                offset = new Vector3(0, 2.5f, 0.3f);
            }
            else
            {
                isThirdPerson = true;
                offset = new Vector3(0, 5, -7);
            }


        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Offest the camera behind the player by adding the offset to the player's position
        transform.position = player.transform.position + offset;

        if (!isThirdPerson)
        {
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.Euler(20.1f, 1.2f, 1.6f);
        }
    }
}
