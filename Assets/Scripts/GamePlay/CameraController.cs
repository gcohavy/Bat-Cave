using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody player;
    private float cameraSpeed = 2;
    private float xBound = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.transform.position.x < transform.position.x && transform.position.x > -xBound)
        {
            transform.Translate(Vector3.left * Time.deltaTime * cameraSpeed);
        }
        else if(player.transform.position.x > transform.position.x && transform.position.x < xBound)
        {
            transform.Translate(Vector3.right * Time.deltaTime * cameraSpeed);
        }
    }
}
