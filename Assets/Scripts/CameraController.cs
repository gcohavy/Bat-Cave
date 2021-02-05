using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float cameraSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < transform.position.x && transform.position.x > -8)
        {
            transform.Translate(Vector3.left * Time.deltaTime * cameraSpeed);
        }
        else if(player.transform.position.x > transform.position.x && transform.position.x < 8)
        {
            transform.Translate(Vector3.right * Time.deltaTime * cameraSpeed);
        }
    }
}
