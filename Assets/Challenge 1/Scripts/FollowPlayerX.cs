using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(30,0,0);

    // Start is called before the first frame update
    void Start()
    {
        //make the camera rotate so it appears to be besides the plane.
        transform.rotation = Quaternion.Euler(0,270,0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //apply the offset to the camera
        transform.position = plane.transform.position + offset;
    }
}
